using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class AtestadoImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atestado",
                schema: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAtestado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "varchar(max)", nullable: false),
                    UrlAnexo = table.Column<string>(type: "varchar(max)", nullable: false),
                    ownerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atestado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atestado_Funcionario_ownerId",
                        column: x => x.ownerId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_ownerId",
                schema: "Funcionarios",
                table: "Atestado",
                column: "ownerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atestado",
                schema: "Funcionarios");
        }
    }
}
