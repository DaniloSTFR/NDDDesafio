using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cliente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "CPF", "DataNascimento", "Email", "Nome", "Observacao", "Sexo", "Telefone" },
                values: new object[,]
                {
                    { new Guid("8ca2ef90-5078-42f0-aee7-13610bdec03c"), "27201891030", new DateTime(2009, 5, 9, 11, 15, 0, 0, DateTimeKind.Unspecified), "mariasantos@email.com", "Maria Santos", "N/A", "Feminino", "91982731359" },
                    { new Guid("c406794e-77f1-400c-9c0a-827cbe1beafa"), "44984736046", new DateTime(1996, 10, 3, 14, 15, 0, 0, DateTimeKind.Unspecified), "antoniosilva@email.com", "Antonio Silva", "N/A", "Masculino", "91967831359" },
                    { new Guid("faf12856-af40-4033-bf4b-9695b9456168"), "22390798004", new DateTime(2005, 1, 10, 10, 15, 0, 0, DateTimeKind.Unspecified), "joaocarlos@email.com", "João Carlos", "N/A", "Masculino", "91992731154" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
