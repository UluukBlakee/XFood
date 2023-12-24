using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedManagerModelAndUpdateCriterion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFactors_CheckLists_CheckListId",
                table: "CategoryFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PizzeriaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "Criteria",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PizzeriaId",
                table: "Criteria",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "CategoryFactors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PizzeriaId",
                table: "CategoryFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    PizzeriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Pizzerias_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_PizzeriaId",
                table: "Criteria",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFactors_PizzeriaId",
                table: "CategoryFactors",
                column: "PizzeriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_PizzeriaId",
                table: "Managers",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFactors_CheckLists_CheckListId",
                table: "CategoryFactors",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFactors_Pizzerias_PizzeriaId",
                table: "CategoryFactors",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_Pizzerias_PizzeriaId",
                table: "Criteria",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFactors_CheckLists_CheckListId",
                table: "CategoryFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFactors_Pizzerias_PizzeriaId",
                table: "CategoryFactors");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteria_Pizzerias_PizzeriaId",
                table: "Criteria");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Criteria_PizzeriaId",
                table: "Criteria");

            migrationBuilder.DropIndex(
                name: "IX_CategoryFactors_PizzeriaId",
                table: "CategoryFactors");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "Criteria");

            migrationBuilder.DropColumn(
                name: "PizzeriaId",
                table: "CategoryFactors");

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "Criteria",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CheckListId",
                table: "CategoryFactors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PizzeriaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PizzeriaId",
                table: "AspNetUsers",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Pizzerias_PizzeriaId",
                table: "AspNetUsers",
                column: "PizzeriaId",
                principalTable: "Pizzerias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFactors_CheckLists_CheckListId",
                table: "CategoryFactors",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteria_CheckLists_CheckListId",
                table: "Criteria",
                column: "CheckListId",
                principalTable: "CheckLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
