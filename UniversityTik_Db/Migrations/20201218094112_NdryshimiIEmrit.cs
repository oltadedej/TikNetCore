using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityTik_Db.Migrations
{
    public partial class NdryshimiIEmrit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Student",
                newName: "Name");
        }
    }
}
