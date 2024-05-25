using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CepAPI.Migrations
{
    /// <inheritdoc />
    public partial class novascolunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Localizacao",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Localizacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Localizacao");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Localizacao");
        }
    }
}
