using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class ModelsReviewedAndSportClubsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnglishGroups_Groups_GroupId",
                table: "EnglishGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyEntries_Groups_GroupId",
                table: "SurveyEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads");

            migrationBuilder.DropIndex(
                name: "IX_SurveyEntries_GroupId",
                table: "SurveyEntries");

            migrationBuilder.DropIndex(
                name: "IX_EnglishGroups_GroupId",
                table: "EnglishGroups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "SurveyEntries");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "EnglishGroups");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Workloads",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Workloads",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EnglishGroupId",
                table: "Workloads",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportClubId",
                table: "Workloads",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SportClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportClubs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workloads_EnglishGroupId",
                table: "Workloads",
                column: "EnglishGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Workloads_SportClubId",
                table: "Workloads",
                column: "SportClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_EnglishGroups_EnglishGroupId",
                table: "Workloads",
                column: "EnglishGroupId",
                principalTable: "EnglishGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_SportClubs_SportClubId",
                table: "Workloads",
                column: "SportClubId",
                principalTable: "SportClubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_EnglishGroups_EnglishGroupId",
                table: "Workloads");

            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_SportClubs_SportClubId",
                table: "Workloads");

            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads");

            migrationBuilder.DropTable(
                name: "SportClubs");

            migrationBuilder.DropIndex(
                name: "IX_Workloads_EnglishGroupId",
                table: "Workloads");

            migrationBuilder.DropIndex(
                name: "IX_Workloads_SportClubId",
                table: "Workloads");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Workloads");

            migrationBuilder.DropColumn(
                name: "EnglishGroupId",
                table: "Workloads");

            migrationBuilder.DropColumn(
                name: "SportClubId",
                table: "Workloads");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "Workloads",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "SurveyEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "EnglishGroups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEntries_GroupId",
                table: "SurveyEntries",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishGroups_GroupId",
                table: "EnglishGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnglishGroups_Groups_GroupId",
                table: "EnglishGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyEntries_Groups_GroupId",
                table: "SurveyEntries",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_Surveys_SurveyId",
                table: "Workloads",
                column: "SurveyId",
                principalTable: "Surveys",
                principalColumn: "Id");
        }
    }
}
