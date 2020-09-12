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
            optionsBuilder
                .UseMySQL("server=localhost;database=CustomerManagement;user=root;password=678150400");
                //.UseLazyLoadingProxies()
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.Entity<Cliente>().HasData(
            //new Cliente("Alnas", "Marks Jons", new DateTime(2000,01,01),
            //    0, "email@email.com", "44999558877"));

            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}