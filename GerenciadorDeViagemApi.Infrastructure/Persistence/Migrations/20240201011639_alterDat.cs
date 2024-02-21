using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class alterDat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAprovacaoRecusa",
                table: "Viagens",
                newName: "DataAprovacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataAprovacao",
                table: "Viagens",
                newName: "DataAprovacaoRecusa");
        }
    }
}
