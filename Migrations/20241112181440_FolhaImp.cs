using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class FolhaImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folha",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasTrabalhadas = table.Column<int>(type: "int", nullable: false),
                    UrlPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folha_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folha");
        }
    }
}
