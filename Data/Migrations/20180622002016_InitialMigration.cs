using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    CadastroConfirmado = table.Column<bool>(nullable: false),
                    Lembrar = table.Column<bool>(nullable: false),
                    Ddd = table.Column<int>(nullable: false),
                    Telefone = table.Column<int>(maxLength: 9, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    CPFCNPJ = table.Column<string>(maxLength: 14, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Id",
                table: "Usuarios",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
