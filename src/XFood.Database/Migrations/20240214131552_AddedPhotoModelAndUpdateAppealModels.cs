using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class AddedPhotoModelAndUpdateAppealModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Appeals",
                newName: "Reply");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Appeals",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateApplication",
                table: "Appeals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReply",
                table: "Appeals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Appeals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    AppealId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Appeals_AppealId",
                        column: x => x.AppealId,
                        principalTable: "Appeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AppealId",
                table: "Photos",
                column: "AppealId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "DateApplication",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "DateReply",
                table: "Appeals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appeals");

            migrationBuilder.RenameColumn(
                name: "Reply",
                table: "Appeals",
                newName: "Description");
        }
    }
}
