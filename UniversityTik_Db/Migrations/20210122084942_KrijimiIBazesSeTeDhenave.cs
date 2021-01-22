using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTik_Db.Migrations
{
    public partial class KrijimiIBazesSeTeDhenave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrrollmentDate",
                table: "Enrollment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EnrrollmentDate",
                table: "Enrollment",
                type: "datetime2",
                nullable: true);
        }
    }
}
