using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class novoCampoPrimeiroAcessoInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrimeiroAcesso",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimeiroAcesso",
                table: "Usuario");
        }
    }
}
