using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class AddTypesOfAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Property",
                table: "TypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 1, 3, "Amenity" });

            migrationBuilder.InsertData(
                schema: "Property",
                table: "TypesOfAttributes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 2, 3, "Policy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Property",
                table: "TypesOfAttributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Property",
                table: "TypesOfAttributes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}