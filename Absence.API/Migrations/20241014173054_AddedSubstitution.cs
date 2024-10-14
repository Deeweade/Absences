using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSubstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Substitutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeePId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubstitutePId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substitutions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Substitutions");
        }
    }
}
