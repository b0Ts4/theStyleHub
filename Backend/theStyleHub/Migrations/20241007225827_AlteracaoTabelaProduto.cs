using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theStyleHub.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoTabelaProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Produtos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Produtos",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Produtos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Produtos");
        }
    }
}
