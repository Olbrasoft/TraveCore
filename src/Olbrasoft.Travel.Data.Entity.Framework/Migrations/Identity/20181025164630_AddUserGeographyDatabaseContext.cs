using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Identity
{
    public partial class AddUserGeographyDatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "6bc41f9a-5a86-4b3b-ad54-e17c0630fbe7", null, false, false, null, null, null, null, null, false, null, false, "GeographyDatabaseContext" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
