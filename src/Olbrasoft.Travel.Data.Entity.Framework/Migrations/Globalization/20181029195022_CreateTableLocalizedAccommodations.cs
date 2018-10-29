using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableLocalizedAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalizedAccommodations",
                schema: "Globalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Location = table.Column<string>(maxLength: 80, nullable: true),
                    CheckInTime = table.Column<string>(maxLength: 10, nullable: true),
                    CheckOutTime = table.Column<string>(maxLength: 10, nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedAccommodations", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedAccommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedAccommodations_Accommodations_Id",
                        column: x => x.Id,
                        principalSchema: "Property",
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedAccommodations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedAccommodations_CreatorId",
                schema: "Globalization",
                table: "LocalizedAccommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedAccommodations_LanguageId",
                schema: "Globalization",
                table: "LocalizedAccommodations",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedAccommodations",
                schema: "Globalization");
        }
    }
}