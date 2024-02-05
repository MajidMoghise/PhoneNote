using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.ConfigRegistration
{
    public static class PhoneNoteInfrastructurePersistsEFCoreConfig
    {
        public static IServiceCollection PhoneNoteInfrastructurePersistsEFCoreRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            return services.DbContextRegistration(configuration)
                           .RepositoryRegistration();
        }
    }
}
