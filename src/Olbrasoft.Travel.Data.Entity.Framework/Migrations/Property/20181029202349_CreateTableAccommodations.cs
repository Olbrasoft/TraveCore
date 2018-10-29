using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTableAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodations",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfAccommodationId = table.Column<int>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    StarRating = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalAddress = table.Column<string>(maxLength: 50, nullable: true),
                    CenterCoordinates = table.Column<IPoint>(nullable: false),
                    ChainId = table.Column<int>(nullable: false, defaultValue: 0),
                    CountryId = table.Column<int>(nullable: false),
                    AirportId = table.Column<int>(nullable: true),
                    EanId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Airports_AirportId",
                        column: x => x.AirportId,
                        principalSchema: "Geography",
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_Chains_ChainId",
                        column: x => x.ChainId,
                        principalSchema: "Property",
                        principalTable: "Chains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geography",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodations_TypesOfAccommodations_TypeOfAccommodationId",
                        column: x => x.TypeOfAccommodationId,
                        principalSchema: "Property",
                        principalTable: "TypesOfAccommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AirportId",
                schema: "Property",
                table: "Accommodations",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_ChainId",
                schema: "Property",
                table: "Accommodations",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_CountryId",
                schema: "Property",
                table: "Accommodations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_CreatorId",
                schema: "Property",
                table: "Accommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_EanId",
                schema: "Property",
                table: "Accommodations",
                column: "EanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_TypeOfAccommodationId",
                schema: "Property",
                table: "Accommodations",
                column: "TypeOfAccommodationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodations",
                schema: "Property");
        }
    }
}