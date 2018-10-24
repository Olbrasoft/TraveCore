using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Geography
{
    public partial class RegionsToTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Geography");

            migrationBuilder.CreateTable(
                name: "RegionsToTypes",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    SubClassId = table.Column<int>(nullable: true),
                    RegionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionsToTypes", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_RegionsToTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionsToTypes_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegionsToTypes_SubClasses_SubClassId",
                        column: x => x.SubClassId,
                        principalSchema: "Geography",
                        principalTable: "SubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionsToTypes_TypesOfRegions_ToId",
                        column: x => x.ToId,
                        principalSchema: "Geography",
                        principalTable: "TypesOfRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionsToTypes_CreatorId",
                schema: "Geography",
                table: "RegionsToTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionsToTypes_RegionId",
                schema: "Geography",
                table: "RegionsToTypes",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionsToTypes_SubClassId",
                schema: "Geography",
                table: "RegionsToTypes",
                column: "SubClassId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionsToTypes_ToId",
                schema: "Geography",
                table: "RegionsToTypes",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionsToTypes",
                schema: "Geography");
        }
    }
}