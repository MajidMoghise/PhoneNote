using Microsoft.Extensions.DependencyInjection;
using PhoneNote.Domain.Contract.Contracts.People;
using PhoneNote.Domain.Contract.Contracts.Phones;
using PhoneNote.Infrastructure.Persists.EFCore.Repository.People;
using PhoneNote.Infrastructure.Persists.EFCore.Repository.Phones;

namespace PhoneNote.Infrastructure.Persists.EFCore.ConfigRegistration
{
    internal static class RepositoryConfig
    {
        internal static IServiceCollection RepositoryRegistration(this IServiceCollection services)
        {

          return  services.AddScoped<IPhoneRepository, PhoneRepository>()
                    .AddScoped<IPersonRepository, PersonRepository>();

        }
    }
}
