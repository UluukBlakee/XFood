using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class PizzeriaDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzerias",
                columns: new[] { "Id", "Name", "Region" },
                values: new object[] { 1, "Пиццерия 1", "Москва" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
