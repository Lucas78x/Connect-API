using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class RelatoBugImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bugs");

            migrationBuilder.CreateTable(
                name: "Relatos",
                schema: "Bugs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false),
                    Funcionario = table.Column<string>(type: "varchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatos",
                schema: "Bugs");
        }
    }
}
