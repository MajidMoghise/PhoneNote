using IDP.Presentation.API.Middelwares;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace IDP.Presentation.API.Configs
{
    internal class GeneralRegistration
    {
        private IServiceCollection _services;
        private IApplicationBuilder _app;
        const string fa_IR = "fa-IR";
        const string en_US="en-US";
        public GeneralRegistration(IServiceCollection services)
        {
            _services = services;
        }
        public GeneralRegistration(IApplicationBuilder app)
        {
            _app = app;
        }
        internal IServiceCollection GeneralServiceRegistration()
        {
            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return _services;
        }
        internal IServiceCollection LocalizationService()
        {
           
            _services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(en_US),
                    new CultureInfo(fa_IR)
                };

                options.DefaultRequestCulture = new RequestCulture(culture: en_US, uiCulture: en_US);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                {
                // My custom request culture logic
                string url = context.Request.Path;
                    if (url.Contains("/fa/"))
                    {
                        return await Task.FromResult(new ProviderCultureResult(fa_IR));
                    }
                    return await Task.FromResult(new ProviderCultureResult(en_US));
                }));
            });

            return _services.AddLocalization(options =>
              {

                  options.ResourcesPath = "Resources";
                  var defaultCulture = new CultureInfo(en_US);
                  CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
                  CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

              });

        }
        internal IApplicationBuilder LocalizationConfig()
        {
            var supportedCultures = new[] { "en", "fa" };
            var localizationOptions = new RequestLocalizationOptions() { ApplyCurrentCultureToResponseHeaders = true }
                                                                      .SetDefaultCulture(supportedCultures[0])
                                                                      .AddSupportedCultures(supportedCultures)
                                                                      .AddSupportedUICultures(supportedCultures);

            _app.UseRequestLocalization(localizationOptions);
            return _app;
        }

    }

}
