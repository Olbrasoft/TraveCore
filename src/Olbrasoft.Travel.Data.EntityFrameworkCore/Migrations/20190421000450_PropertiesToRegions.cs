using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Migrations
{
    public partial class PropertiesToRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertiesToRegions",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesToRegions", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_PropertiesToRegions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertiesToRegions_Properties_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertiesToRegions_Regions_ToId",
                        column: x => x.ToId,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ae97093f-a250-461f-b943-70e7e0de01d8");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesToRegions_CreatorId",
                schema: "Accommodation",
                table: "PropertiesToRegions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesToRegions_ToId",
                schema: "Accommodation",
                table: "PropertiesToRegions",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertiesToRegions",
                schema: "Accommodation");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c1239bc6-1d50-43e4-b282-64b4cb23ccdc");
        }
    }
}
