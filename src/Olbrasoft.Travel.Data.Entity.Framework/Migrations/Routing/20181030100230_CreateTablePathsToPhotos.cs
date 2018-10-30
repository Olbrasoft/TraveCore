using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Routing
{
    public partial class CreateTablePathsToPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Routing");

            migrationBuilder.CreateTable(
                name: "PathsToPhotos",
                schema: "Routing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Path = table.Column<string>(maxLength: 300, nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathsToPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathsToPhotos_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PathsToPhotos_CreatorId",
                schema: "Routing",
                table: "PathsToPhotos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PathsToPhotos_Path",
                schema: "Routing",
                table: "PathsToPhotos",
                column: "Path",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PathsToPhotos",
                schema: "Routing");
        }
    }
}
