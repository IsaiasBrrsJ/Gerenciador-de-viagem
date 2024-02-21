using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tesste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagem_Usuario_UsuarioAprovadorMatricula",
                table: "Viagem");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagem_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Viagem",
                table: "Viagem");

            migrationBuilder.DropCheckConstraint(
                name: "conts",
                table: "Viagem");

            migrationBuilder.RenameTable(
                name: "Viagem",
                newName: "Viagems");

            migrationBuilder.RenameIndex(
                name: "IX_Viagem_UsuarioSolicitanteMatricula",
                table: "Viagems",
                newName: "IX_Viagems_UsuarioSolicitanteMatricula");

            migrationBuilder.RenameIndex(
                name: "IX_Viagem_UsuarioAprovadorMatricula",
                table: "Viagems",
                newName: "IX_Viagems_UsuarioAprovadorMatricula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viagems",
                table: "Viagems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagems_Usuario_UsuarioAprovadorMatricula",
                table: "Viagems",
                column: "UsuarioAprovadorMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagems_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagems",
                column: "UsuarioSolicitanteMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagems_Usuario_UsuarioAprovadorMatricula",
                table: "Viagems");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagems_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Viagems",
                table: "Viagems");

            migrationBuilder.RenameTable(
                name: "Viagems",
                newName: "Viagem");

            migrationBuilder.RenameIndex(
                name: "IX_Viagems_UsuarioSolicitanteMatricula",
                table: "Viagem",
                newName: "IX_Viagem_UsuarioSolicitanteMatricula");

            migrationBuilder.RenameIndex(
                name: "IX_Viagems_UsuarioAprovadorMatricula",
                table: "Viagem",
                newName: "IX_Viagem_UsuarioAprovadorMatricula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viagem",
                table: "Viagem",
                column: "Id");

            migrationBuilder.AddCheckConstraint(
                name: "conts",
                table: "Viagem",
                sql: "UsuarioSolicitanteMatricula != UsuarioAprovadorMatricula AND UsuarioAprovadorMatricula !=3131");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagem_Usuario_UsuarioAprovadorMatricula",
                table: "Viagem",
                column: "UsuarioAprovadorMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagem_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagem",
                column: "UsuarioSolicitanteMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
