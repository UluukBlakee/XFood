using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedCriticalFactorDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CriticalFactors");

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "CriticalFactors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CriticalFactorDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriticalFactorId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriticalFactorDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriticalFactorDescriptions_CriticalFactors_CriticalFactorId",
                        column: x => x.CriticalFactorId,
                        principalTable: "CriticalFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CriticalFactors",
                columns: new[] { "Id", "CheckListId", "CriterionId", "MaxPoints" },
                values: new object[,]
                {
                    { 1, null, 31, -4 },
                    { 2, null, 31, -4 },
                    { 3, null, 31, -4 },
                    { 4, null, 32, -8 },
                    { 5, null, 32, -8 },
                    { 6, null, 32, -8 },
                    { 7, null, 32, -8 },
                    { 8, null, 32, -8 }
                });

            migrationBuilder.InsertData(
                table: "CriticalFactorDescriptions",
                columns: new[] { "Id", "CriticalFactorId", "Description" },
                values: new object[,]
                {
                    { 1, 1, "лотки на печи" },
                    { 2, 2, "продукт достали ранее чем он выехал на 2/3 из печи" },
                    { 3, 3, "пиццу достали ранее чем она выехала на 2/3 из печи" },
                    { 4, 4, "Руки перед работой с продуктом помыты без антисептика." },
                    { 5, 5, "Нарушен принцип пищевое/непищевое:\r\nповерхность не опищевили после этого. \r\nво время уборки в перчатках касаются пищевых лотков/посуды/продуктов." },
                    { 6, 6, "Использование просроченных ингредиентов, перемаркировка." },
                    { 7, 7, "Заготовка ингредиента в грязную (или со старым ингредиентом) гастроемкость/бутылку." },
                    { 8, 8, "Использование теста с утра, которое ранее выносили на нагрев и занесли обратно в холодильник (вечером в конце смены)." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CriticalFactorDescriptions_CriticalFactorId",
                table: "CriticalFactorDescriptions",
                column: "CriticalFactorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors");

            migrationBuilder.DropTable(
                name: "CriticalFactorDescriptions");

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CriticalFactors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "CriticalFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CriticalFactors",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CriticalFactors_CheckLists_CheckListId",
                table: "CriticalFactors",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
