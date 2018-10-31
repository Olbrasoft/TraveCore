using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class AddSubTypesOfAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 1, 3, "AmenityOfAccommodation" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 2, 3, "AmenityOfRoom" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 3, 3, "CheckInOut" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 4, 3, "Other" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 5, 3, "Payment" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 6, 3, "Pets" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "SubTypesOfAttributes",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}