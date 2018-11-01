using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableAccommodationsToAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationsToAttributes",
                schema: "Globalization",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 800, nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationsToAttributes", x => new { x.AccommodationId, x.AttributeId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_AccommodationsToAttributes_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalSchema: "Property",
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationsToAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Property",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccommodationsToAttributes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccommodationsToAttributes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationsToAttributes_AttributeId",
                schema: "Globalization",
                table: "AccommodationsToAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationsToAttributes_CreatorId",
                schema: "Globalization",
                table: "AccommodationsToAttributes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationsToAttributes_LanguageId",
                schema: "Globalization",
                table: "AccommodationsToAttributes",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationsToAttributes",
                schema: "Globalization");
        }
    }
}
