using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Infrastructure.Data.Mappings
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> b)
        {
            b.ToTable("Clientes");

            b.Property(c => c.Id).HasColumnType("CHAR(36)");
            b.HasKey(c => c.Id);

            b.Property(c => c.Nome)
                .HasMaxLength(20)
                .IsRequired();

            b.Property(c => c.Sobrenome)
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
              .HasColumnType("CHAR(11)");

            b.Ignore(e => e.ValidationResult);
            b.Ignore(e => e.CascadeMode);
        }
    }
}