using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class TipoTelefoneEDddUsuarioTexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Ddd",
                table: "Usuarios",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Usuarios",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<int>(
                name: "Ddd",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }
    }
}
