using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevPratica.Locacao.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCampoEmailEnviado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailEnviado",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailEnviado",
                table: "Clientes");
        }
    }
}
