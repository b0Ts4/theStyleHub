using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace theStyleHub.Migrations
{
    /// <inheritdoc />
    public partial class SenhaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hash_senha",
                table: "Usuarios",
                type: "varchar(300)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hash_senha",
                table: "Usuarios");
        }
    }
}
