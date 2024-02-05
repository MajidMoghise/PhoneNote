using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PhoneNote.Presentation.API.Middelwares
{
    public class AutorizationMiddelware : IMiddleware
    {


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tokenstr = context.Request.Headers.Authorization;
            var checkExistAtt = await CheckExistAttributeAuth(context);
            if (!string.IsNullOrEmpty(tokenstr))
            {
                var jwtToken = tokenstr.ToString().Replace("Bearer ", "").Replace("{", "").Replace("}", "");

                context.RequestServices.GetService<KeycloakModel>().Token = jwtToken;
                var service = context.RequestServices.GetService<IUserProvider>();
                var clientId = context.RequestServices.GetService<KeycloakModel>().ClientId;
                if (string.Equals(clientId, "admin-cli", StringComparison.CurrentCultureIgnoreCase))
                {
                    ///this code is not valid admin-cli is not valid for Introspect
                    //var result = await service.Introspect(
                    //   new Domain.Contract.Providers.Keycloak.Roles.Models.IntrospectRequestModelProvider { AccessToken = jwtToken });
                    var jwt = JWTDecryption(jwtToken);

                    var roleClaim = new Claim(ClaimTypes.Role, "Admin");
                    var claims = new List<Claim>();
                    claims.Add(roleClaim);
                    claims.AddRange(jwt.Claims);

                    var userPrincipal = context.User;
                    userPrincipal.AddIdentity(new ClaimsIdentity(claims, "Bearer"));
                    context.User = userPrincipal;

                }
                else
                {
                    var result = await service.Introspect(
                        new Domain.Contract.Providers.Keycloak.Roles.Models.IntrospectRequestModelProvider { AccessToken = jwtToken });

                    var claims = new List<Claim> {
                        new Claim("UserId", result.sub.ToString()),
                        new Claim("UserName", result.preferred_username.ToString()),
                    };
                    foreach (var item in result.GetType().GetProperties())
                    {
                        var propName = item.Name;
                        var propValue = item.GetValue(result);
                        claims.Add(new Claim(propName.ToString(), propValue.ToString()));
                    }
                    var identity = new ClaimsIdentity(claims, "Bearer");
                    var principal = new ClaimsPrincipal(identity);
                    context.User = principal;
                    //var claims = jwtToken.Claims;
                    //    context.User.AddIdentity(new System.Security.Claims.ClaimsIdentity(result.typ, result.typ, ""));
                    //    context.User.AddIdentities(new List<System.Security.Claims.ClaimsIdentity> {
                    //        new System.Security.Claims.ClaimsIdentity(){"Bearer ", result.typ, "" } ,
                    //        new System.Security.Claims.ClaimsIdentity("UserId", result.sub.ToString(), "") ,
                    //        new System.Security.Claims.ClaimsIdentity("UserName", result.preferred_username.ToString(), "")
                    //});
                }
            }
            else if (checkExistAtt)
            {
                throw new BusinessException("Unauthorized", BusinessExceptionType.Unauthorized);
            }


            await next(context);
        }
        private JwtSecurityToken JWTDecryption(string key)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(key);


        }
        private Task<bool> CheckExistAttributeAuth(HttpContext httpContext)
        {
            var endpoint = httpContext.GetEndpoint();
            if (endpoint != null && endpoint is RouteEndpoint routeEndpoint)
            {
                var metadata = routeEndpoint.Metadata;
                if (metadata.GetMetadata<AuthorizeAttribute>() == null)
                {
                    return Task.FromResult(false);
                }
            }
            return Task.FromResult(true);
        }
    }
}
