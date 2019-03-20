using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Migrations
{
    public partial class AddIndexTableLocalizedRealEstatesColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "df24b686-7b7d-4907-a042-0cc04c559345");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRealEstates_Name",
                schema: "Accommodation",
                table: "LocalizedRealEstates",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocalizedRealEstates_Name",
                schema: "Accommodation",
                table: "LocalizedRealEstates");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "699f91b5-0f5e-42c6-8f87-ee626bd113f8");
        }
    }
}
