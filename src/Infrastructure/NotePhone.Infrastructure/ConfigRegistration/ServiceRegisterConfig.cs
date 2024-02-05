using Microsoft.Extensions.DependencyInjection;

namespace NotePhone.Infrastructure.ConfigRegistration
{
    public static class ServiceRegisterConfig
    {
        public static IServiceCollection ServiceRegistration(this IServiceCollection services)
        {
            return services;
        }
    }
}
