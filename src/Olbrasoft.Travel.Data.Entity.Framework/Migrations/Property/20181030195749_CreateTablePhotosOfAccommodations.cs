using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Property
{
    public partial class CreateTablePhotosOfAccommodations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhotosOfAccommodations",
                schema: "Property",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccommodationId = table.Column<int>(nullable: false),
                    PathToPhotoId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: true),
                    FileExtensionId = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    CaptionId = table.Column<int>(nullable: true),
                    CreatorId = table.Column<int>(nullable: false),
                    DateAndTimeOfCreation = table.Column<DateTime>(nullable: false, defaultValueSql: "getutcdate()"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosOfAccommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalSchema: "Property",
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodations_Captions_CaptionId",
                        column: x => x.CaptionId,
                        principalSchema: "Property",
                        principalTable: "Captions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodations_FilesExtensions_FileExtensionId",
                        column: x => x.FileExtensionId,
                        principalSchema: "Routing",
                        principalTable: "FilesExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotosOfAccommodations_PathsToPhotos_PathToPhotoId",
                        column: x => x.PathToPhotoId,
                        principalSchema: "Routing",
                        principalTable: "PathsToPhotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodations_AccommodationId",
                schema: "Property",
                table: "PhotosOfAccommodations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodations_CaptionId",
                schema: "Property",
                table: "PhotosOfAccommodations",
                column: "CaptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodations_CreatorId",
                schema: "Property",
                table: "PhotosOfAccommodations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodations_FileExtensionId",
                schema: "Property",
                table: "PhotosOfAccommodations",
                column: "FileExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosOfAccommodations_PathToPhotoId_FileName_FileExtensionId",
                schema: "Property",
                table: "PhotosOfAccommodations",
                columns: new[] { "PathToPhotoId", "FileName", "FileExtensionId" },
                unique: true,
                filter: "[FileName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotosOfAccommodations",
                schema: "Property");
        }
    }
}