using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducaRank.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salas_Professores_ProfessorId",
                table: "Salas");

            migrationBuilder.DropIndex(
                name: "IX_Salas_ProfessorId",
                table: "Salas");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Salas");

            migrationBuilder.AddColumn<string>(
                name: "Materias",
                table: "Professores",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materias",
                table: "Professores");

            migrationBuilder.AddColumn<string>(
                name: "ProfessorId",
                table: "Salas",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salas_ProfessorId",
                table: "Salas",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salas_Professores_ProfessorId",
                table: "Salas",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id");
        }
    }
}
