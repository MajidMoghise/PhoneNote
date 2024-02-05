using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Entities;

namespace PhoneNote.Infrastructure.Persists.EFCore.Configs
{
    internal static class PhoneTypeModelCreating 
    {       
        internal static ModelBuilder PhoneTypeConfig(this ModelBuilder modelBuilder)
        {
           return modelBuilder.Entity<PhoneType>(entity =>
           {
                entity.ToTable(name: "PhoneType", "np");

               entity.Property(x => x.Id);
             
               entity.Property(e => e.Name)
                      .HasColumnType("nvarchar(50)");

            });

        }
    }

}
