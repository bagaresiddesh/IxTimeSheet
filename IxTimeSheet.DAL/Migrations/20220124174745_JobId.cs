using Microsoft.EntityFrameworkCore.Migrations;

namespace IxTimeSheet.DAL.Migrations
{
    public partial class JobId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "Jobs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_PId",
                table: "Jobs",
                column: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Clients_PId",
                table: "Jobs",
                column: "PId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Clients_PId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_PId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "Jobs");
        }
    }
}
