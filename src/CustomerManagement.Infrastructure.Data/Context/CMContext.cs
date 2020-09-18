using CustomerManagement.Domain.Entities;
using CustomerManagement.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data.Context
{
    public class CMContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public CMContext(DbContextOptions<CMContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}