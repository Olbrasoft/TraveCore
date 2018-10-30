using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTableTypesOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesOfRooms",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccommodationId = table.Column<int>(nullable: false),
                    EanId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypesOfRooms_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalSchema: "Property",
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypesOfRooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfRooms_AccommodationId",
                schema: "Property",
                table: "TypesOfRooms",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_TypesOfRooms_CreatorId",
                schema: "Property",
                table: "TypesOfRooms",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesOfRooms",
                schema: "Property");
        }
    }
}