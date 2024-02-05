using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using PhoneNote.Infrastructure.Persists.EFCore.ConfigRegistration;

namespace NotePhone.Infrastructure.ConfigRegistration
{
    public static class ApplicationConfigs
    {
        public static IServiceCollection Registration(this IServiceCollection services,IConfiguration configuration)
        {
            return services.PhoneNoteInfrastructurePersistsEFCoreRegistration(configuration)
                           .ServiceRegistration();
        }
    }
}
