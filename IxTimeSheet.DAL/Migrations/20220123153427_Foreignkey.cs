using Microsoft.EntityFrameworkCore.Migrations;

namespace IxTimeSheet.DAL.Migrations
{
    public partial class Foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "CID",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CID",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
