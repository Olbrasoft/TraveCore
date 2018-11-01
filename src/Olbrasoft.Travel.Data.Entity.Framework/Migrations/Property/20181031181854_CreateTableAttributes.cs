using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTableAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfAttributeId = table.Column<int>(nullable: false),
                    SubTypeOfAttributeId = table.Column<int>(nullable: false),
                    EanId = table.Column<int>(nullable: false),
                    Ban = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attributes_SubTypesOfAttributes_SubTypeOfAttributeId",
                        column: x => x.SubTypeOfAttributeId,
                        principalSchema: "Property",
                        principalTable: "SubTypesOfAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributes_TypesOfAttributes_TypeOfAttributeId",
                        column: x => x.TypeOfAttributeId,
                        principalSchema: "Property",
                        principalTable: "TypesOfAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_CreatorId",
                schema: "Property",
                table: "Attributes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_SubTypeOfAttributeId",
                schema: "Property",
                table: "Attributes",
                column: "SubTypeOfAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_TypeOfAttributeId",
                schema: "Property",
                table: "Attributes",
                column: "TypeOfAttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Property");
        }
    }
}