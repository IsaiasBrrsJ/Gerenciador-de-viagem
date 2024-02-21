using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateconstraintap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "conts",
                table: "Viagem");

            migrationBuilder.AddCheckConstraint(
                name: "conts",
                table: "Viagem",
                sql: "UsuarioSolicitanteMatricula != UsuarioAprovadorMatricula AND UsuarioAprovadorMatricula !=3131");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "conts",
                table: "Viagem");

            migrationBuilder.AddCheckConstraint(
                name: "conts",
                table: "Viagem",
                sql: "UsuarioSolicitanteMatricula != UsuarioAprovadorMatricula or UsuarioAprovadorMatricula !=3131");
        }
    }
}
