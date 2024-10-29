using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class WorkdayType_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWorkingDay",
                table: "WorkPeriods");

            migrationBuilder.AddColumn<int>(
                name: "WorkdayTypeId",
                table: "WorkPeriods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkdayTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkdayTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkPeriods_WorkdayTypeId",
                table: "WorkPeriods",
                column: "WorkdayTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkPeriods_WorkdayTypes_WorkdayTypeId",
                table: "WorkPeriods",
                column: "WorkdayTypeId",
                principalTable: "WorkdayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkPeriods_WorkdayTypes_WorkdayTypeId",
                table: "WorkPeriods");

            migrationBuilder.DropTable(
                name: "WorkdayTypes");

            migrationBuilder.DropIndex(
                name: "IX_WorkPeriods_WorkdayTypeId",
                table: "WorkPeriods");

            migrationBuilder.DropColumn(
                name: "WorkdayTypeId",
                table: "WorkPeriods");

            migrationBuilder.AddColumn<bool>(
                name: "IsWorkingDay",
                table: "WorkPeriods",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
