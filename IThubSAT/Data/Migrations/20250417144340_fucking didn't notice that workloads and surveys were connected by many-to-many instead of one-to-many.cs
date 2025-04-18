using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class fuckingdidntnoticethatworkloadsandsurveyswereconnectedbymanytomanyinsteadofonetomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyWorkload");

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Workloads",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workloads_SurveyId",
                table: "Workloads",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads");

            migrationBuilder.DropIndex(
                name: "IX_Workloads_SurveyId",
                table: "Workloads");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Workloads");

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
        }
    }
}
