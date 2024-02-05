using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Entities;

namespace PhoneNote.Infrastructure.Persists.EFCore.Configs
{
    internal static class PersonTypeModelCreating 
    {       
        internal static ModelBuilder PersonTypeConfig(this ModelBuilder modelBuilder)
        {
           return modelBuilder.Entity<PersonType>(entity =>
           {
                entity.ToTable(name: "PersonType", "np");

               entity.Property(x => x.Id);
             
               entity.Property(e => e.Name)
                      .HasColumnType("nvarchar(50)");

            });

        }
    }

}
