using CustomerManagement.Domain.Entities;
using CustomerManagement.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.Infrastructure.Data.Context
{
    public class CMContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            GetConnection(optionsBuilder);
            //.UseLazyLoadingProxies()
        }

        protected virtual void GetConnection(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL("server=localhost;database=CustomerManagement;user=root;password=678150400");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}