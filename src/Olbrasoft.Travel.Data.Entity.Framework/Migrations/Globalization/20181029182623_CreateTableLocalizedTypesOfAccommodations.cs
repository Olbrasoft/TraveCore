using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableLocalizedTypesOfAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalizedTypesOfAccommodations",
                schema: "Globalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedTypesOfAccommodations", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfAccommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfAccommodations_TypesOfAccommodations_Id",
                        column: x => x.Id,
                        principalSchema: "Property",
                        principalTable: "TypesOfAccommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfAccommodations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedTypesOfAccommodations_CreatorId",
                schema: "Globalization",
                table: "LocalizedTypesOfAccommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedTypesOfAccommodations_LanguageId",
                schema: "Globalization",
                table: "LocalizedTypesOfAccommodations",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedTypesOfAccommodations",
                schema: "Globalization");
        }
    }
}