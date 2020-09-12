﻿// <auto-generated />
using System;
using CustomerManagement.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerManagement.Infrastructure.Data.Migrations
{
    [DbContext(typeof(CMContext))]
    partial class CMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CustomerManagement.Domain.Entities.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .HasColumnType("VARCHAR(11)");

                    b.Property<int>("TipoSexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Telefone")
                        .HasName("idx_cliente_telefone");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CustomerManagement.Domain.Entities.Endereco", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("CHAR(8)")
                        .HasMaxLength(8);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ClienteId")
                        .IsRequired()
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("DescricaoEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<string>("UfEstado")
                        .IsRequired()
                        .HasColumnName("UF")
                        .HasColumnType("CHAR(2)")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("CustomerManagement.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("CustomerManagement.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Enderecos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
