using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class Substitutions_ChangedFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubstitutePId",
                table: "Substitutions",
                newName: "DeputyPId");

            migrationBuilder.AddColumn<string>(
                name: "MANAGER_PID",
                table: "Position_And_Employees_On_Day",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MANAGER_PID",
                table: "Position_And_Employees_On_Day");

            migrationBuilder.RenameColumn(
                name: "DeputyPId",
                table: "Substitutions",
                newName: "SubstitutePId");
        }
    }
}
