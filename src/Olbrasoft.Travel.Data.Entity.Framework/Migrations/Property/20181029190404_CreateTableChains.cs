using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTableChains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chains",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    EanId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chains_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chains_CreatorId",
                schema: "Property",
                table: "Chains",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chains_EanId",
                schema: "Property",
                table: "Chains",
                column: "EanId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chains",
                schema: "Property");
        }
    }
}