
using PhoneNote.Presentation.API.Middelwares;
using System;
using System.Reflection;

namespace PhoneNote.Presentation.API.Configs
{
    internal class MiddelwareRegistration
    {
        private IServiceCollection _services;
        private IApplicationBuilder _app;
        public MiddelwareRegistration(IServiceCollection services)
        {
            _services = services;
        }
        public MiddelwareRegistration(IApplicationBuilder app)
        {
            _app = app;
        }

        internal IServiceCollection MiddelwareRegister()
        {
            _services.AddTransient<ExceptionMiddelware>();
            _services.AddScoped<AutorizationMiddelware>();
            return _services;
        }
        internal IApplicationBuilder MiddelwareConfig()
        {
            _app.UseMiddleware<ExceptionMiddelware>();
            _app.UseMiddleware<AutorizationMiddelware>();

            return _app;
        }
    }

}
