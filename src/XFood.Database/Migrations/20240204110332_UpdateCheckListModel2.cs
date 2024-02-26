using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class UpdateCheckListModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CheckLists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_UserId",
                table: "CheckLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_AspNetUsers_UserId",
                table: "CheckLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_AspNetUsers_UserId",
                table: "CheckLists");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_UserId",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CheckLists");
        }
    }
}
