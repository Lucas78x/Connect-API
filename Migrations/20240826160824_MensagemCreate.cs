using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class MensagemCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Chat");

            migrationBuilder.CreateTable(
                name: "Mensagem",
                schema: "Chat",
                columns: table => new
                {
                    MensagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemetenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinatarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagem", x => x.MensagemId);
                    table.ForeignKey(
                        name: "FK_Mensagem_Funcionario_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mensagem_Funcionario_RemetenteId",
                        column: x => x.RemetenteId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_DestinatarioId",
                schema: "Chat",
                table: "Mensagem",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagem_RemetenteId",
                schema: "Chat",
                table: "Mensagem",
                column: "RemetenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mensagem",
                schema: "Chat");
        }
    }
}
