using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NormalizedEmailAndUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Usuarios");
        }
    }
}
