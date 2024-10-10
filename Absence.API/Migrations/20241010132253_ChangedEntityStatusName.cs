using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacations.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityStatusName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_EntityStatuses_EntityStatusId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_EntityStatusId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeStatuses");

            migrationBuilder.AddColumn<int>(
                name: "AbsenceStatusId",
                table: "Absences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_AbsenceStatusId",
                table: "Absences",
                column: "AbsenceStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_EntityStatuses_AbsenceStatusId",
                table: "Absences",
                column: "AbsenceStatusId",
                principalTable: "EntityStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_EntityStatuses_AbsenceStatusId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_AbsenceStatusId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "AbsenceStatusId",
                table: "Absences");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EntityStatusId",
                table: "Absences",
                column: "EntityStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_EntityStatuses_EntityStatusId",
                table: "Absences",
                column: "EntityStatusId",
                principalTable: "EntityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
