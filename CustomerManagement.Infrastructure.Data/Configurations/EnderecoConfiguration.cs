using CustomerManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagement.Infrastructure.Data.Mappings
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> b)
        {
            b.ToTable("Enderecos");

            b.Property(c => c.Id)
               .HasColumnType("CHAR(36)")
               .ValueGeneratedOnAdd();

            b.Property(c => c.CEP)
                .HasColumnType("CHAR(8)")
                .HasMaxLength(8)
                .IsRequired();

            b.Property(c => c.Logradouro)
                .HasMaxLength(50)
                .IsRequired();

            b.Property(c => c.DescricaoEndereco)
                .HasMaxLength(150)
                .IsRequired();

            b.Property(c => c.Numero)
                .HasColumnType("VARCHAR(20)")
                 .HasMaxLength(20)
                .IsRequired();

            b.Property(c => c.Bairro)
                 .HasMaxLength(150)
                .IsRequired();

            b.Property(c => c.Complemento)
                 .HasMaxLength(150);

            b.Property(c => c.Cidade)
                 .HasMaxLength(50)
                .IsRequired();

            b.Property(c => c.UfEstado)
                .HasColumnName("UF")
                .HasColumnType("CHAR(2)")
                .HasMaxLength(2)
                .IsRequired();

            b.HasOne<Cliente>(c => c.Cliente)
                .WithMany(e => e.Enderecos)
                .HasForeignKey(c => c.ClienteId);

            b.Ignore(e => e.ValidationResult);
            b.Ignore(e => e.CascadeMode);
        }
    }
}
