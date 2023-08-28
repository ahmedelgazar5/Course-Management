using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseManagmentDAL.Migrations
{
    /// <inheritdoc />
    public partial class durationColumnRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Sessions");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMins",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMins",
                table: "Sessions");

            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                table: "Sessions",
                type: "datetime2",
                nullable: true);
        }
    }
}
