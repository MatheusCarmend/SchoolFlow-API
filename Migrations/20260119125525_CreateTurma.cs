using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFlow.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nivel",
                table: "Turmas",
                newName: "Periodo");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Turmas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Turmas");

            migrationBuilder.RenameColumn(
                name: "Periodo",
                table: "Turmas",
                newName: "Nivel");
        }
    }
}
