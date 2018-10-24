using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class LocalizedRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Globalization");

            migrationBuilder.CreateTable(
                name: "LocalizedRegions",
                schema: "Globalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    LongName = table.Column<string>(maxLength: 510, nullable: true),
                    RegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRegions", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_CreatorId",
                schema: "Globalization",
                table: "LocalizedRegions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_LanguageId",
                schema: "Globalization",
                table: "LocalizedRegions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_RegionId",
                schema: "Globalization",
                table: "LocalizedRegions",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedRegions",
                schema: "Globalization");
        }
    }
}