using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneNote.Domain.Entities;
using PhoneNote.Infrastructure.Persists.EFCore.Configs;
using System.Reflection.Emit;
using System.Transactions;

namespace PhoneNote.Infrastructure.Persists.EFCore
{
    public partial class Ef_DbContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;
        public Ef_DbContext(
            DbContextOptions<Ef_DbContext> options,
                IConfiguration configuration
                )
            : base(options)
        {
            _connectionString = configuration.GetSection("Connections:SqlConnection").Value.ToString();
            _configuration = configuration;

        }
        public Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction Transaction { get; set; }

        public TransactionStatus TransactionStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.GetModelBuilder();

        }
        public DbSet<Phone> Phones{ get; set; }
        public DbSet<Person> People{ get; set; }
        public DbSet<PersonType> PersonTypes{ get; set; }
        public DbSet<PhoneType> PhoneTypes{ get; set; }

    }
}
