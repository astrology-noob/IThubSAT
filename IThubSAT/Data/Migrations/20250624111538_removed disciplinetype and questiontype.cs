using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class removeddisciplinetypeandquestiontype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineType",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentsInGroup",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisciplineType",
                table: "Disciplines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisciplineType",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "StudentsInGroup",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "DisciplineType",
                table: "Disciplines");
        }
    }
}
