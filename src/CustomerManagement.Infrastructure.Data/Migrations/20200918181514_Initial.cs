using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Nome = table.Column<string>(maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    TipoSexo = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(type: "CHAR(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Logradouro = table.Column<string>(maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Complemento = table.Column<string>(maxLength: 150, nullable: true),
                    Bairro = table.Column<string>(maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Localidade = table.Column<string>(maxLength: 50, nullable: false),
                    UF = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    ClienteId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cliente_telefone",
                table: "Clientes",
                column: "Telefone");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
