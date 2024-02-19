using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class UpdateCheckListModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "CheckLists",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "CheckLists");
        }
    }
}
