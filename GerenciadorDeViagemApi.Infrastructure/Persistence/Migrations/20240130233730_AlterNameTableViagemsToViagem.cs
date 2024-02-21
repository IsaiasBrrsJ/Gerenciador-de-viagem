using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterNameTableViagemsToViagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                newName: "Viagens");

            migrationBuilder.RenameIndex(
                name: "IX_Viagems_UsuarioSolicitanteMatricula",
                table: "Viagens",
                newName: "IX_Viagens_UsuarioSolicitanteMatricula");

            migrationBuilder.RenameIndex(
                name: "IX_Viagems_UsuarioAprovadorMatricula",
                table: "Viagens",
                newName: "IX_Viagens_UsuarioAprovadorMatricula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Usuario_UsuarioAprovadorMatricula",
                table: "Viagens",
                column: "UsuarioAprovadorMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagens",
                column: "UsuarioSolicitanteMatricula",
                principalTable: "Usuario",
                principalColumn: "Matricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Usuario_UsuarioAprovadorMatricula",
                table: "Viagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Usuario_UsuarioSolicitanteMatricula",
                table: "Viagens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Viagens",
                table: "Viagens");

            migrationBuilder.RenameTable(
                name: "Viagens",
                newName: "Viagems");

            migrationBuilder.RenameIndex(
                name: "IX_Viagens_UsuarioSolicitanteMatricula",
                table: "Viagems",
                newName: "IX_Viagems_UsuarioSolicitanteMatricula");

            migrationBuilder.RenameIndex(
                name: "IX_Viagens_UsuarioAprovadorMatricula",
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
    }
}
