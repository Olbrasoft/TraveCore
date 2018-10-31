using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTablePhotosOfAccommodationsToTypesOfRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotosOfAccommodationsToTypesOfRooms",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosOfAccommodationsToTypesOfRooms", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodationsToTypesOfRooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodationsToTypesOfRooms_PhotosOfAccommodations_Id",
                        column: x => x.Id,
                        principalSchema: "Property",
                        principalTable: "PhotosOfAccommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodationsToTypesOfRooms_TypesOfRooms_ToId",
                        column: x => x.ToId,
                        principalSchema: "Property",
                        principalTable: "TypesOfRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodationsToTypesOfRooms_CreatorId",
                schema: "Property",
                table: "PhotosOfAccommodationsToTypesOfRooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodationsToTypesOfRooms_ToId",
                schema: "Property",
                table: "PhotosOfAccommodationsToTypesOfRooms",
                column: "ToId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosOfAccommodationsToTypesOfRooms",
                schema: "Property");
        }
    }
}