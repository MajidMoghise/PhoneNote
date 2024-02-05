using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.Configs
{
    internal static class DomainModelCreating
    {
        internal static ModelBuilder GetModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.PersonConfig();
            modelBuilder.PhoneConfig();
            modelBuilder.PhoneTypeConfig();
            modelBuilder.PersonTypeConfig();
            return modelBuilder;
        }
    }
}
