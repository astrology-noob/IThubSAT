using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyrelationshipsnotationssimplified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsInSurveys_QuestionTypes_VisibleForQuestionTypeId",
                table: "QuestionsInSurveys");

            migrationBuilder.DropTable(
                name: "WorkloadsInSurveys");

            migrationBuilder.RenameColumn(
                name: "VisibleForQuestionTypeId",
                table: "QuestionsInSurveys",
                newName: "VisibleForDisciplineTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsInSurveys_VisibleForQuestionTypeId",
                table: "QuestionsInSurveys",
                newName: "IX_QuestionsInSurveys_VisibleForDisciplineTypeId");

            migrationBuilder.CreateTable(
                name: "SurveyWorkload",
                columns: table => new
                {
                    SurveysId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkloadsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyWorkload", x => new { x.SurveysId, x.WorkloadsId });
                    table.ForeignKey(
                        name: "FK_SurveyWorkload_Surveys_SurveysId",
                        column: x => x.SurveysId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyWorkload_Workloads_WorkloadsId",
                        column: x => x.WorkloadsId,
                        principalTable: "Workloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyWorkload_WorkloadsId",
                table: "SurveyWorkload",
                column: "WorkloadsId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsInSurveys_DisciplineTypes_VisibleForDisciplineTypeId",
                table: "QuestionsInSurveys",
                column: "VisibleForDisciplineTypeId",
                principalTable: "DisciplineTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsInSurveys_DisciplineTypes_VisibleForDisciplineTypeId",
                table: "QuestionsInSurveys");

            migrationBuilder.DropTable(
                name: "SurveyWorkload");

            migrationBuilder.RenameColumn(
                name: "VisibleForDisciplineTypeId",
                table: "QuestionsInSurveys",
                newName: "VisibleForQuestionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionsInSurveys_VisibleForDisciplineTypeId",
                table: "QuestionsInSurveys",
                newName: "IX_QuestionsInSurveys_VisibleForQuestionTypeId");

            migrationBuilder.CreateTable(
                name: "WorkloadsInSurveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SurveyId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkloadId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkloadsInSurveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkloadsInSurveys_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkloadsInSurveys_Workloads_WorkloadId",
                        column: x => x.WorkloadId,
                        principalTable: "Workloads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkloadsInSurveys_SurveyId",
                table: "WorkloadsInSurveys",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkloadsInSurveys_WorkloadId",
                table: "WorkloadsInSurveys",
                column: "WorkloadId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsInSurveys_QuestionTypes_VisibleForQuestionTypeId",
                table: "QuestionsInSurveys",
                column: "VisibleForQuestionTypeId",
                principalTable: "QuestionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
