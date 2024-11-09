using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Absence.API.Migrations
{
    /// <inheritdoc />
    public partial class Substitutions_AddedDateStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateStart",
                table: "Substitutions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Substitutions");
        }
    }
}
