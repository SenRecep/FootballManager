using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballManager.Dal.Migrations
{
    public partial class _inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Money",
                table: "Users",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Teamid",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Teamid",
                table: "Users",
                column: "Teamid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_Teamid",
                table: "Users",
                column: "Teamid",
                principalTable: "Teams",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_Teamid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Teamid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Teamid",
                table: "Users");
        }
    }
}
