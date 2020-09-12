using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace CustomerManagement.Infrastructure.Data.Mappings
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> b)
        {
            b.ToTable("Clientes");

            b.Property(c => c.Id)
                .HasColumnType("CHAR(36)");

            b.Property(c => c.Nome)
                .HasColumnType("VARCHAR(20)")
                .HasMaxLength(20)
                .IsRequired();

            b.Property(c => c.SobreNome)
                 .HasMaxLength(100)
                .IsRequired();

            b.Property(c => c.DataNascimento)
                .HasColumnType("DATE")
                .IsRequired();

            b.Property(c => c.TipoSexo)
                .HasConversion<int>();

            b.Property(c => c.Email)
                .HasMaxLength(100);

            b.Property(c => c.Email)
               .HasMaxLength(100);

            b.Property(c => c.Telefone)
              .HasColumnType("VARCHAR(11)");

            b.HasIndex(c => c.Telefone)
                .HasName("idx_cliente_telefone");

            b.Ignore(e => e.ValidationResult);
            b.Ignore(e => e.CascadeMode);
        }
    }
}