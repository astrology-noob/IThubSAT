using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class SectionTypesremovednahuyandafewSurveyfieldsadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SectionTypes_SectionTypeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "SectionTypes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_SectionTypeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "SectionTypeId",
                table: "Questions");

            migrationBuilder.AddColumn<string>(
                name: "ConclusionText",
                table: "Surveys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IntroductionText",
                table: "Surveys",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConclusionText",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "IntroductionText",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "SectionTypeId",
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
                name: "IX_Questions_SectionTypeId",
                table: "Questions",
                column: "SectionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SectionTypes_SectionTypeId",
                table: "Questions",
                column: "SectionTypeId",
                principalTable: "SectionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
