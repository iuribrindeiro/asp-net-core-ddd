using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TamanhoMaximoUserName20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
