using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaRank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoreMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Curso",
                table: "Alunos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "Alunos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
