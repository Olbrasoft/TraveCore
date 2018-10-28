using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Geography
{
    public partial class AddTypesOfRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 1, 1, "World", "World" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 2, 1, "Continent", "Continent" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 3, 1, "Country", "Country" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 4, 1, "Province (State)", "Province" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 5, 1, "Multi-Region (within a country)", "MultiRegion" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 6, 1, "Multi-City (Vicinity)", "MultiCity" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 7, 1, "City", "City" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 8, 1, "Neighborhood", "Neighborhood" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 9, 1, "Point of Interest", "PointOfInterest" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 10, 1, "Point of Interest Shadow", "PointOfInterestShadow" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 11, 1, "Airport", "Airport" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "TypesOfRegions",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 12, 1, "Train Station", "TrainStation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Geography",
                table: "TypesOfRegions",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
