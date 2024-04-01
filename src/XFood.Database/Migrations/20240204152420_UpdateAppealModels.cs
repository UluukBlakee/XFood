using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class UpdateAppealModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChecklistCriteriaId",
                table: "Appeals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 62,
                column: "PizzeriaId",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Appeals_ChecklistCriteriaId",
                table: "Appeals",
                column: "ChecklistCriteriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appeals_ChecklistCriteria_ChecklistCriteriaId",
                table: "Appeals",
                column: "ChecklistCriteriaId",
                principalTable: "ChecklistCriteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appeals_ChecklistCriteria_ChecklistCriteriaId",
                table: "Appeals");

            migrationBuilder.DropIndex(
                name: "IX_Appeals_ChecklistCriteriaId",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "ChecklistCriteriaId",
                table: "Appeals");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 62,
                column: "PizzeriaId",
                value: 1);
        }
    }
}
