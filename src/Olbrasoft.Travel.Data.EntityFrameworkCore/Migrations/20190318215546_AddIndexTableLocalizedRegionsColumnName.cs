using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Migrations
{
    public partial class AddIndexTableLocalizedRegionsColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "699f91b5-0f5e-42c6-8f87-ee626bd113f8");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_Name",
                schema: "Geography",
                table: "LocalizedRegions",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LocalizedRegions_Name",
                schema: "Geography",
                table: "LocalizedRegions");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5abb44c9-726b-40ad-a7c3-2cbc80d6aac5");
        }
    }
}
