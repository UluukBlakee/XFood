using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class RemovePizzeriaFromAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PizzeriaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "PizzeriaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
