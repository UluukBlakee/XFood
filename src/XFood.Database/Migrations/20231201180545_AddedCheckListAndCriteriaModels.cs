using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedCheckListAndCriteriaModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PizzeriaId = table.Column<int>(type: "integer", nullable: false),
                    StartCheck = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndCheck = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ReceivedPoints = table.Column<int>(type: "integer", nullable: false),
                    CheckListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryFactors_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MaxPoints = table.Column<int>(type: "integer", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: true),
                    ReceivedPoints = table.Column<int>(type: "integer", nullable: false),
                    CheckListId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Criteria_CheckLists_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriticalFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MaxPoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriticalFactors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriticalFactors_CategoryFactors_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFactors_CheckListId",
                table: "CategoryFactors",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteria_CheckListId",
                table: "Criteria",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CriticalFactors_CategoryId",
                table: "CriticalFactors",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "CriticalFactors");

            migrationBuilder.DropTable(
                name: "CategoryFactors");

            migrationBuilder.DropTable(
                name: "CheckLists");
        }
    }
}
