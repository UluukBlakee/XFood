using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndWork",
                table: "OpportunitySchedules");

            migrationBuilder.RenameColumn(
                name: "StartWork",
                table: "OpportunitySchedules",
                newName: "Day");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeZone",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartOfPeriod = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    EndOfPeriod = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    OpportunityScheduleId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Time_OpportunitySchedules_OpportunityScheduleId",
                        column: x => x.OpportunityScheduleId,
                        principalTable: "OpportunitySchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Time_OpportunityScheduleId",
                table: "Time",
                column: "OpportunityScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropColumn(
                name: "TimeZone",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "OpportunitySchedules",
                newName: "StartWork");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndWork",
                table: "OpportunitySchedules",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
