using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class QuestionTypeInfoAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeInfoMask",
                table: "QuestionTypes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionTypeInfo",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeInfoMask",
                table: "QuestionTypes");

            migrationBuilder.DropColumn(
                name: "QuestionTypeInfo",
                table: "Questions");
        }
    }
}
