using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedCheckListCriteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CriticalFactors_CategoryFactors_CategoryId",
                table: "CriticalFactors");

            migrationBuilder.DropTable(
                name: "CategoryFactors");

            migrationBuilder.DropColumn(
                name: "ReceivedPoints",
                table: "Criteria");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CriticalFactors",
                newName: "CriterionId");

            migrationBuilder.RenameIndex(
                name: "IX_CriticalFactors_CategoryId",
                table: "CriticalFactors",
                newName: "IX_CriticalFactors_CriterionId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndCheck",
                table: "CheckLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "CheckLists",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartCheck",
                table: "CheckLists",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ChecklistCriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CriterionId = table.Column<int>(type: "integer", nullable: false),
                    CheckListId = table.Column<int>(type: "integer", nullable: false),
                    ReceivedPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistCriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistCriteria_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChecklistCriteria_Criteria_CriterionId",
                        column: x => x.CriterionId,
                        principalTable: "Criteria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckLists_ManagerId",
                table: "CheckLists",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistCriteria_CheckListId",
                table: "ChecklistCriteria",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistCriteria_CriterionId",
                table: "ChecklistCriteria",
                column: "CriterionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckLists_Managers_ManagerId",
                table: "CheckLists",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CriticalFactors_Criteria_CriterionId",
                table: "CriticalFactors",
                column: "CriterionId",
                principalTable: "Criteria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckLists_Managers_ManagerId",
                table: "CheckLists");

            migrationBuilder.DropForeignKey(
                name: "FK_CriticalFactors_Criteria_CriterionId",
                table: "CriticalFactors");

            migrationBuilder.DropTable(
                name: "ChecklistCriteria");

            migrationBuilder.DropIndex(
                name: "IX_CheckLists_ManagerId",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "EndCheck",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "CheckLists");

            migrationBuilder.DropColumn(
                name: "StartCheck",
                table: "CheckLists");

            migrationBuilder.RenameColumn(
                name: "CriterionId",
                table: "CriticalFactors",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CriticalFactors_CriterionId",
                table: "CriticalFactors",
                newName: "IX_CriticalFactors_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ReceivedPoints",
                table: "Criteria",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzeriaId = table.Column<int>(type: "integer", nullable: false),
                    CheckListId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ReceivedPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryFactors_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryFactors_Pizzerias_PizzeriaId",
                        column: x => x.PizzeriaId,
                        principalTable: "Pizzerias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFactors_CheckListId",
                table: "CategoryFactors",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFactors_PizzeriaId",
                table: "CategoryFactors",
                column: "PizzeriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CriticalFactors_CategoryFactors_CategoryId",
                table: "CriticalFactors",
                column: "CategoryId",
                principalTable: "CategoryFactors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
