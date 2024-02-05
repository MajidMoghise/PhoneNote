using IDP.Presentation.API.Configs;
using NotePhone.Infrastructure.ConfigRegistration;


namespace PhoneNote.Presentation.API.Configs
{
    public static class ConfigsAndRegistration
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services = new GeneralRegistration(services).GeneralServiceRegistration();
            services = new MiddelwareRegistration(services).MiddelwareRegister();
            services.Registration(configuration);
            return services;
        }
        public static IApplicationBuilder AppConfig(this IApplicationBuilder app)
        {
            app = new MiddelwareRegistration(app).MiddelwareConfig();
            
            return app;
        }
    }
}
