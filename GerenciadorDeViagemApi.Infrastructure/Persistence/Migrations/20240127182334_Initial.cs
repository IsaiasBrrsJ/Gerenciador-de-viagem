using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<long>(type: "BIGINT", nullable: false),
                    Email = table.Column<string>(type: "varchar(45)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", nullable: false),
                    TipoDeUsuario = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false),
                    Senha = table.Column<string>(type: "NVarChar(max)", nullable: false),
                    UltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<byte>(type: "tinyint", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.UniqueConstraint("AK_Usuario_Matricula", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Viagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataVolta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTransporte = table.Column<byte>(type: "tinyint", nullable: false),
                    DataDaSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAprovacaoRecusa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusViagem = table.Column<byte>(type: "tinyint", nullable: false),
                    UsuarioSolicitanteMatricula = table.Column<long>(type: "BIGINT", nullable: false),
                    UsuarioAprovadorMatricula = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagem", x => x.Id);
                    table.CheckConstraint("conts", "UsuarioSolicitanteMatricula != UsuarioAprovadorMatricula");
                    table.ForeignKey(
                        name: "FK_Viagem_Usuario_UsuarioAprovadorMatricula",
                        column: x => x.UsuarioAprovadorMatricula,
                        principalTable: "Usuario",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viagem_Usuario_UsuarioSolicitanteMatricula",
                        column: x => x.UsuarioSolicitanteMatricula,
                        principalTable: "Usuario",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_UsuarioAprovadorMatricula",
                table: "Viagem",
                column: "UsuarioAprovadorMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Viagem_UsuarioSolicitanteMatricula",
                table: "Viagem",
                column: "UsuarioSolicitanteMatricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viagem");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
