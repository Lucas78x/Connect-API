using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Connect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Funcionarios");

            migrationBuilder.EnsureSchema(
                name: "Comunicados");

            migrationBuilder.EnsureSchema(
                name: "Eventos");

            migrationBuilder.EnsureSchema(
                name: "Chat");

            migrationBuilder.EnsureSchema(
                name: "Bugs");

            migrationBuilder.EnsureSchema(
                name: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Comunicados",
                schema: "Comunicados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(max)", nullable: false),
                    Mensagem = table.Column<string>(type: "varchar(max)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunicados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                schema: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Setor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                schema: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    RG = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Cargo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Permissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Requisicoes",
                schema: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Setor = table.Column<int>(type: "int", nullable: false),
                    RequisitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    DescricaoSolucao = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Ferias",
                schema: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ferias_Funcionario_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Folha",
                schema: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAtual = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasTrabalhadas = table.Column<string>(type: "varchar(max)", nullable: false),
                    UrlPdf = table.Column<string>(type: "varchar(max)", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folha_Funcionario_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(max)", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalSchema: "Funcionarios",
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atestado_ownerId",
                schema: "Funcionarios",
                table: "Atestado",
                column: "ownerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_OwnerId",
                schema: "Funcionarios",
                table: "Ferias",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folha_OwnerId",
                schema: "Funcionarios",
                table: "Folha",
                column: "OwnerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_FuncionarioId",
                schema: "Usuarios",
                table: "Usuario",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atestado",
                schema: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Comunicados",
                schema: "Comunicados");

            migrationBuilder.DropTable(
                name: "Eventos",
                schema: "Eventos");

            migrationBuilder.DropTable(
                name: "Ferias",
                schema: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Folha",
                schema: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Mensagem",
                schema: "Chat");

            migrationBuilder.DropTable(
                name: "Relatos",
                schema: "Bugs");

            migrationBuilder.DropTable(
                name: "Requisicoes",
                schema: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Usuarios");

            migrationBuilder.DropTable(
                name: "Funcionario",
                schema: "Funcionarios");
        }
    }
}
