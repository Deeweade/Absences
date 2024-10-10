using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacations.API.Migrations
{
    /// <inheritdoc />
    public partial class LinkedDaysAndAbsenceType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegularDaysCount",
                table: "VacationDays",
                newName: "DaysNumber");

            migrationBuilder.RenameColumn(
                name: "NorthernDaysCount",
                table: "VacationDays",
                newName: "AbsenceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationDays_AbsenceTypeId",
                table: "VacationDays",
                column: "AbsenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationDays_AbsenceTypes_AbsenceTypeId",
                table: "VacationDays",
                column: "AbsenceTypeId",
                principalTable: "AbsenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationDays_AbsenceTypes_AbsenceTypeId",
                table: "VacationDays");

            migrationBuilder.DropIndex(
                name: "IX_VacationDays_AbsenceTypeId",
                table: "VacationDays");

            migrationBuilder.RenameColumn(
                name: "DaysNumber",
                table: "VacationDays",
                newName: "RegularDaysCount");

            migrationBuilder.RenameColumn(
                name: "AbsenceTypeId",
                table: "VacationDays",
                newName: "NorthernDaysCount");
        }
    }
}
