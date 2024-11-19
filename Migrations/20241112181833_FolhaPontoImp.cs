using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class FolhaPontoImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folha_Funcionario_FuncionarioId",
                table: "Folha");

            migrationBuilder.DropIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folha");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Folha");

            migrationBuilder.RenameTable(
                name: "Folha",
                newName: "Folha",
                newSchema: "Funcionarios");

            migrationBuilder.AlterColumn<string>(
                name: "UrlPdf",
                schema: "Funcionarios",
                table: "Folha",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HorasTrabalhadas",
                schema: "Funcionarios",
                table: "Folha",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Folha_OwnerId",
                schema: "Funcionarios",
                table: "Folha",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folha_Funcionario_OwnerId",
                schema: "Funcionarios",
                table: "Folha",
                column: "OwnerId",
                principalSchema: "Funcionarios",
                principalTable: "Funcionario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folha_Funcionario_OwnerId",
                schema: "Funcionarios",
                table: "Folha");

            migrationBuilder.DropIndex(
                name: "IX_Folha_OwnerId",
                schema: "Funcionarios",
                table: "Folha");

            migrationBuilder.RenameTable(
                name: "Folha",
                schema: "Funcionarios",
                newName: "Folha");

            migrationBuilder.AlterColumn<string>(
                name: "UrlPdf",
                table: "Folha",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "HorasTrabalhadas",
                table: "Folha",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionarioId",
                table: "Folha",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folha_Funcionario_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId",
                principalSchema: "Funcionarios",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
