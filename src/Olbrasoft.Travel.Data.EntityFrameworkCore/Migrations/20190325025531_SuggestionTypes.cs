using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Migrations
{
    public partial class SuggestionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SuggestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Ascending = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestionTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestionTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedSuggestionTypes",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Label = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedSuggestionTypes", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedSuggestionTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedSuggestionTypes_SuggestionTypes_Id",
                        column: x => x.Id,
                        principalTable: "SuggestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedSuggestionTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "SuggestionTypes",
                columns: new[] { "Id", "Ascending", "CreatorId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "SuggestionTypes",
                columns: new[] { "Id", "Ascending", "CreatorId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "SuggestionTypes",
                columns: new[] { "Id", "Ascending", "CreatorId" },
                values: new object[] { 3, 3, 1 });

            migrationBuilder.InsertData(
                table: "SuggestionTypes",
                columns: new[] { "Id", "Ascending", "CreatorId" },
                values: new object[] { 4, 4, 1 });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "54941ec9-60fe-42e8-b578-00aa1aa89de2");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestionTypes_CreatorId",
                table: "SuggestionTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedSuggestionTypes_CreatorId",
                schema: "Localization",
                table: "LocalizedSuggestionTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedSuggestionTypes_LanguageId",
                schema: "Localization",
                table: "LocalizedSuggestionTypes",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedSuggestionTypes",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "SuggestionTypes");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "df24b686-7b7d-4907-a042-0cc04c559345");
        }
    }
}
