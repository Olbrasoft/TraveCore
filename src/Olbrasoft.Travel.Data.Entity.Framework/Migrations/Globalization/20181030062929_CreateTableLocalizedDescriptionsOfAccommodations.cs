using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableLocalizedDescriptionsOfAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalizedDescriptionsOfAccommodations",
                schema: "Globalization",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(nullable: false),
                    TypeOfDescriptionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedDescriptionsOfAccommodations", x => new { x.AccommodationId, x.TypeOfDescriptionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptionsOfAccommodations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalSchema: "Property",
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptionsOfAccommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptionsOfAccommodations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptionsOfAccommodations_TypesOfDescriptions_TypeOfDescriptionId",
                        column: x => x.TypeOfDescriptionId,
                        principalSchema: "Property",
                        principalTable: "TypesOfDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptionsOfAccommodations_CreatorId",
                schema: "Globalization",
                table: "LocalizedDescriptionsOfAccommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptionsOfAccommodations_LanguageId",
                schema: "Globalization",
                table: "LocalizedDescriptionsOfAccommodations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptionsOfAccommodations_TypeOfDescriptionId",
                schema: "Globalization",
                table: "LocalizedDescriptionsOfAccommodations",
                column: "TypeOfDescriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedDescriptionsOfAccommodations",
                schema: "Globalization");
        }
    }
}