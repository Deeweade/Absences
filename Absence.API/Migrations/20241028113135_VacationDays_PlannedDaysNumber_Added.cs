using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class VacationDays_PlannedDaysNumber_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaysNumber",
                table: "VacationDays",
                newName: "AvailableDaysNumber");

            migrationBuilder.AddColumn<int>(
                name: "PlannedDaysNumber",
                table: "VacationDays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannedDaysNumber",
                table: "VacationDays");

            migrationBuilder.RenameColumn(
                name: "AvailableDaysNumber",
                table: "VacationDays",
                newName: "DaysNumber");
        }
    }
}
