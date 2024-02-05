using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhoneNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.Configs
{

    internal static class PersonModelCreating 
    {       
        internal static ModelBuilder PersonConfig(this ModelBuilder modelBuilder)
        {
           return modelBuilder.Entity<Person>(entity =>
           {
                entity.ToTable(name: "People", "np");
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

                entity.Property(e => e.Email)
                      .HasColumnType("nvarchar(500)");

                entity.Property(e => e.NationalCode)
                      .HasColumnType("nvarchar(12)");

                entity.HasOne(e => e.PersonType)
                      .WithMany()
                      .HasForeignKey(e => e.PersonTypeId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }

}
