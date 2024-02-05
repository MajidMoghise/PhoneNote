using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneNote.Infrastructure.Persists.EFCore.ConfigRegistration
{
    internal static class DbContextConfig
    {
        internal static IServiceCollection DbContextRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var sqlQueryCnn = configuration.GetSection("Connections:SqlConnection").Value;
            services.AddDbContext<Ef_DbContext>(x => x.UseSqlServer(sqlQueryCnn));

            return services;
        }
    }
}
