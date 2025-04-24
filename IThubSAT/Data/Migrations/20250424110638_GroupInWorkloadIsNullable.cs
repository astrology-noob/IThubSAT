using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IThubSAT.Migrations
{
    /// <inheritdoc />
    public partial class GroupInWorkloadIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_Groups_GroupId",
                table: "Workloads");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Workloads",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_Groups_GroupId",
                table: "Workloads",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workloads_Groups_GroupId",
                table: "Workloads");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "Workloads",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Workloads_Groups_GroupId",
                table: "Workloads",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
