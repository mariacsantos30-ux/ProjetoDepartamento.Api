using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoDepartamento.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoAcesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoDeAcesso",
                table: "Departamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoDeAcesso",
                table: "Departamentos");
        }
    }
}
