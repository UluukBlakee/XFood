using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class UpdateCriticalFactorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "CriticalFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CriticalFactors_CheckListId",
                table: "CriticalFactors",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors");

            migrationBuilder.DropIndex(
                name: "IX_CriticalFactors_CheckListId",
                table: "CriticalFactors");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "CriticalFactors");
        }
    }
}
