using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class VacationDays_AddedYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "VacationDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Position_And_Employees_On_Day",
                columns: table => new
                {
                    DATE_FIELD = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TERMINATION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SOPERCENT = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    SPPERCENT = table.Column<decimal>(type: "decimal(18,0)", precision: 18, scale: 0, nullable: true),
                    PID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PGRADE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PGRADESTARTDATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CITY_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HIRED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OFFICENAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CATEGORYNAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LEVEL_7 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Position_And_Employees_On_Day");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "VacationDays");
        }
    }
}
