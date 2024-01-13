using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedEmployeeModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria");

            migrationBuilder.DropIndex(
                name: "IX_Criteria_CheckListId",
                table: "Criteria");

            migrationBuilder.DropColumn(
                name: "CheckListId",
                table: "Criteria");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Managers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "Managers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ContactInfo = table.Column<string>(type: "text", nullable: true),
                    PizzeriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Pizzerias_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "alex@example.com", "@alex_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "ekaterina@example.com", "@ekaterina_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "dmitry@example.com", "@dmitry_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "maria@example.com", "@maria_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "andrey@example.com", "@andrey_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "olga@example.com", "@olga_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "sergey@example.com", "@sergey_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "anastasia@example.com", "@anastasia_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "ivan@example.com", "@ivan_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "elena@example.com", "@elena_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "pavel@example.com", "@pavel_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "alisa@example.com", "@alisa_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "nikita@example.com", "@nikita_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "valeria@example.com", "@valeria_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "grigory@example.com", "@grigory_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "tatiana@example.com", "@tatiana_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "artem@example.com", "@artem_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "evgenia@example.com", "@evgenia_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "maxim@example.com", "@maxim_telegram" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Email", "Telegram" },
                values: new object[] { "viktoria@example.com", "@viktoria_telegram" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PizzeriaId",
                table: "Employees",
                column: "PizzeriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "Managers");

            migrationBuilder.AddColumn<int>(
                name: "CheckListId",
                table: "Criteria",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_CheckListId",
                table: "Criteria",
                column: "CheckListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id");
        }
    }
}
