using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class Realtionshipbetweenquestionsandsurveyschangedtomanytoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisciplineTypeId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionTypeId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SectionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_DisciplineTypeId",
                table: "Questions",
                column: "DisciplineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SectionTypeId",
                table: "Questions",
                column: "SectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_DisciplineTypes_DisciplineTypeId",
                table: "Questions",
                column: "DisciplineTypeId",
                principalTable: "DisciplineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SectionTypes_SectionTypeId",
                table: "Questions",
                column: "SectionTypeId",
                principalTable: "SectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_DisciplineTypes_DisciplineTypeId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SectionTypes_SectionTypeId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Surveys_SurveyId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "SectionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_DisciplineTypeId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SectionTypeId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "DisciplineTypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SectionTypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Questions");
        }
    }
}
