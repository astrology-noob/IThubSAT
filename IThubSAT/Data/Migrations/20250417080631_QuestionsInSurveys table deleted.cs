using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class QuestionsInSurveystabledeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionsInSurveys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionsInSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    VisibleForDisciplineTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsInSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsInSurveys_DisciplineTypes_VisibleForDisciplineTypeId",
                        column: x => x.VisibleForDisciplineTypeId,
                        principalTable: "DisciplineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsInSurveys_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsInSurveys_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsInSurveys_QuestionId",
                table: "QuestionsInSurveys",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsInSurveys_SurveyId",
                table: "QuestionsInSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsInSurveys_VisibleForDisciplineTypeId",
                table: "QuestionsInSurveys",
                column: "VisibleForDisciplineTypeId");
        }
    }
}
