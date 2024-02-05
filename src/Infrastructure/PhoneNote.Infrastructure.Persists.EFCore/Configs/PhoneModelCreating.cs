using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Entities;

namespace PhoneNote.Infrastructure.Persists.EFCore.Configs
{
    internal static class PhoneModelCreating 
    {
       
        internal static ModelBuilder PhoneConfig(this ModelBuilder modelBuilder)
        {
           return modelBuilder.Entity<Phone>(entity =>
           {
                entity.ToTable(name: "Phones", "np");
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Id)
                      .ValueGeneratedOnAdd();
                entity.Property(e => e.IsDeleted)
                         .ValueGeneratedOnAdd()
                         .HasDefaultValue(true);

                entity.Property(e => e.CreateDate)
                      .ValueGeneratedOnAdd()
                      .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Local));

                entity.Property(e => e.UpdateDate)
                     .ValueGeneratedOnAdd()
                     .HasConversion(v => v.HasValue ? v.Value.ToUniversalTime() : (DateTime?)null, v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Local) : (DateTime?)null);

                entity.Property(e => e.RowVersion)
                      .IsRowVersion();

                entity.Property(e => e.PhoneNumber)
                      .HasColumnType("nvarchar(20)");

              

                entity.HasOne(e => e.PhoneType)
                      .WithMany()
                      .HasForeignKey(e => e.PhoneTypeId)
                      .OnDelete(DeleteBehavior.Restrict); 
               
               entity.HasOne(e => e.Person)
                      .WithMany()
                      .HasForeignKey(e => e.PersonId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }

}
