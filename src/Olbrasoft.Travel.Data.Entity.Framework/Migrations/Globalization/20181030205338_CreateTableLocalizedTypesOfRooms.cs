using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableLocalizedTypesOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalizedTypesOfRooms",
                schema: "Globalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedTypesOfRooms", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfRooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfRooms_TypesOfRooms_Id",
                        column: x => x.Id,
                        principalSchema: "Property",
                        principalTable: "TypesOfRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedTypesOfRooms_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Globalization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedTypesOfRooms_CreatorId",
                schema: "Globalization",
                table: "LocalizedTypesOfRooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedTypesOfRooms_LanguageId",
                schema: "Globalization",
                table: "LocalizedTypesOfRooms",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedTypesOfRooms",
                schema: "Globalization");
        }
    }
}