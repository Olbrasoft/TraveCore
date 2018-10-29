using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTableTypesOfAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Property");

            migrationBuilder.CreateTable(
                name: "TypesOfAccommodations",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EanId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfAccommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypesOfAccommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfAccommodations_CreatorId",
                schema: "Property",
                table: "TypesOfAccommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfAccommodations_EanId",
                schema: "Property",
                table: "TypesOfAccommodations",
                column: "EanId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesOfAccommodations",
                schema: "Property");
        }
    }
}