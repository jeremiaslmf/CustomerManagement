using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.IO;

namespace CustomerManagement.Infrastructure.Data.Context
{
    public class CMContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        //public CMContext(DbContextOptions options) : base(options)
        //{
        //    Database.Migrate();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=CustomerManagement;user=root;password=678150400");
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