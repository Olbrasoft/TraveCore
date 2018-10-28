using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Globalization
{
    public partial class CreateTableLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Globalization");

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Globalization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    EanLanguageCode = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatorId",
                schema: "Globalization",
                table: "Languages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_EanLanguageCode",
                schema: "Globalization",
                table: "Languages",
                column: "EanLanguageCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Globalization");
        }
    }
}