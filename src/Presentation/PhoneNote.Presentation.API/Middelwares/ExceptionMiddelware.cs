using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Helper;
using PhoneNote.Infrastructure.Persists.EFCore.Helper;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace PhoneNote.Presentation.API.Middelwares
{
    public class ExceptionMiddelware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)

        {
            var service = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
            try
            {
                // اجرای میدلور بعدی در pipeline
                await next(context);
                if (!service.Disposed)
                {
                    await service.CommitAsync();
                }
            }
            catch (PhoneNote.Application.Contract.Helper.ApplicationException ex)
            {
                context.Response.StatusCode = GetHttpStatus(ex.ExceptionType);
                var response = new BaseResponse
                {
                    Message = ex.Message
                };
                var errorJson = JsonSerializer.Serialize(response);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorJson);
                await service.RollBackAsync();
                await context.Response.WriteAsync(ex.Message);
            }
            catch (ValidationException validation)
            {
                context.Response.StatusCode = GetHttpStatus(ExceptionType.BadRequest);
                var response = new BaseResponse
                {
                    Message = validation.Message
                };
                var errorJson = JsonSerializer.Serialize(response);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorJson);
                await service.RollBackAsync();
                await context.Response.WriteAsJsonAsync(validation.Message);
               
            }
            catch (DomainException ex)
            {

                context.Response.StatusCode = GetHttpStatus(ex.ExceptionType);
                var response = new BaseResponse
                {
                    Message = ex.Message
                };
                var errorJson = JsonSerializer.Serialize(response);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorJson);
                await service.RollBackAsync();
            }catch (InfrastructureEfCoreException ex)
            {
                context.Response.StatusCode = GetHttpStatus(ExceptionType.BadRequest);

                var response = new BaseResponse
                {
                    Message = ex.Message
                };
                var errorJson = JsonSerializer.Serialize(response);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(errorJson);
                await service.RollBackAsync();
            }
            catch
            {

                //// ثبت اکسپشن در لاگر
                //_logger.LogError(ex, ex.Message);

                //// تغییر کد وضعیت پاسخ به 500
                //context.Response.StatusCode = 500;

                //// ایجاد یک مدل خطا برای پاسخ
                //var errorModel = new ErrorModel
                //{
                //    Message = "An unexpected error occurred.",
                //    Details = ex.Message
                //};

                //// تبدیل مدل خطا به رشته JSON
                //var errorJson = JsonSerializer.Serialize(errorModel);

                //// تنظیم محتوای پاسخ به JSON
                //context.Response.ContentType = "application/json";

                //// نوشتن رشته JSON در پاسخ
                //await context.Response.WriteAsync(errorJson);
                await service.RollBackAsync();
                throw;

            }

        }
        private int GetHttpStatus(ExceptionType type)
        {
            if (type == ExceptionType.UnAuthorize)
            {
                return (int)HttpStatusCode.Unauthorized;

            }
            else if (type == ExceptionType.Business)
            {
                return (int)HttpStatusCode.BadRequest;

            }
            else if (type == ExceptionType.BadRequest)
            {
                return (int)HttpStatusCode.BadRequest;

            }
            else if (type == ExceptionType.NotFound)
            {
                return (int)HttpStatusCode.NotFound;

            }
            else if (type == ExceptionType.Forbidden)
            {
                return (int)HttpStatusCode.Forbidden;

            }
            return (int)HttpStatusCode.OK;
        }

    }
}
