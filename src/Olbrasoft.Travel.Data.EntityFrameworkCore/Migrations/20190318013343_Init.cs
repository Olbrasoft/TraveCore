using System;
using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Accommodation");

            migrationBuilder.EnsureSchema(
                name: "Geography");

            migrationBuilder.EnsureSchema(
                name: "IO");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.EnsureSchema(
                name: "Localization");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolesClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersLogins",
                schema: "Identity",
                columns: table => new
                {
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLogins", x => new { x.UserId, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "UsersTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "AttributeSubtypes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeSubtypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeSubtypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Captions",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chains",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    ExpediaId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RealEstateTypes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    ExpediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubClasses",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubClasses_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subtypes",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileExtensions",
                schema: "IO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileExtensions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PathsToPhotos",
                schema: "IO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathsToPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathsToPhotos_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Localization",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    ExpediaCode = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    SubtypeId = table.Column<int>(nullable: false),
                    ExpediaId = table.Column<int>(nullable: false),
                    Ban = table.Column<bool>(nullable: false)
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
                        name: "FK_Attributes_AttributeSubtypes_SubtypeId",
                        column: x => x.SubtypeId,
                        principalSchema: "Accommodation",
                        principalTable: "AttributeSubtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attributes_AttributeTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Accommodation",
                        principalTable: "AttributeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Coordinates = table.Column<IPolygon>(type: "geography", nullable: true),
                    CenterCoordinates = table.Column<IPoint>(type: "geography", nullable: true),
                    ExpediaId = table.Column<long>(nullable: false),
                    SubtypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Regions_Subtypes_SubtypeId",
                        column: x => x.SubtypeId,
                        principalSchema: "Geography",
                        principalTable: "Subtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedCaptions",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedCaptions", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedCaptions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedCaptions_Captions_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "Captions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedCaptions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedRealEstateTypes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRealEstateTypes", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstateTypes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstateTypes_RealEstateTypes_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstateTypes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedAttributes",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedAttributes", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedAttributes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedAttributes_Attributes_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedAttributes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airports_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airports_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Continents_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Continents_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedRegions",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    LongName = table.Column<string>(maxLength: 510, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRegions", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedRegions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegionToRegions",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionToRegions", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_RegionToRegions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionToRegions_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionToRegions_Regions_ToId",
                        column: x => x.ToId,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionToSubclasss",
                schema: "Geography",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionToSubclasss", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_RegionToSubclasss_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegionToSubclasss_Regions_Id",
                        column: x => x.Id,
                        principalSchema: "Geography",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegionToSubclasss_SubClasses_ToId",
                        column: x => x.ToId,
                        principalSchema: "Geography",
                        principalTable: "SubClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    SequenceNumber = table.Column<int>(nullable: false),
                    StarRating = table.Column<decimal>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalAddress = table.Column<string>(maxLength: 50, nullable: true),
                    CenterCoordinates = table.Column<IPoint>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    AirportId = table.Column<int>(nullable: true),
                    ChainId = table.Column<int>(nullable: false, defaultValue: 0),
                    ExpediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstates_Airports_AirportId",
                        column: x => x.AirportId,
                        principalSchema: "Geography",
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_Chains_ChainId",
                        column: x => x.ChainId,
                        principalSchema: "Accommodation",
                        principalTable: "Chains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Geography",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstates_RealEstateTypes_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstateTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedDescriptions",
                schema: "Accommodation",
                columns: table => new
                {
                    RealEstateId = table.Column<int>(nullable: false),
                    DescriptionId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedDescriptions", x => new { x.RealEstateId, x.DescriptionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptions_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptions_Descriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalSchema: "Accommodation",
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedDescriptions_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedRealEstates",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Location = table.Column<string>(maxLength: 80, nullable: true),
                    CheckInTime = table.Column<string>(maxLength: 10, nullable: true),
                    CheckOutTime = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRealEstates", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstates_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstates_RealEstates_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedRealEstates_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    RealEstateId = table.Column<int>(nullable: false),
                    PathToPhotoId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 50, nullable: false),
                    FileExtensionId = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    CaptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Captions_CaptionId",
                        column: x => x.CaptionId,
                        principalSchema: "Accommodation",
                        principalTable: "Captions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_FileExtensions_FileExtensionId",
                        column: x => x.FileExtensionId,
                        principalSchema: "IO",
                        principalTable: "FileExtensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_PathsToPhotos_PathToPhotoId",
                        column: x => x.PathToPhotoId,
                        principalSchema: "IO",
                        principalTable: "PathsToPhotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Photos_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstatesToAttributes",
                schema: "Accommodation",
                columns: table => new
                {
                    RealEstateId = table.Column<int>(nullable: false),
                    AttributeId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    CreatorId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 800, nullable: true),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatesToAttributes", x => new { x.RealEstateId, x.AttributeId, x.LanguageId });
                    table.UniqueConstraint("AK_RealEstatesToAttributes_AttributeId_LanguageId_RealEstateId", x => new { x.AttributeId, x.LanguageId, x.RealEstateId });
                    table.ForeignKey(
                        name: "FK_RealEstatesToAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Accommodation",
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatesToAttributes_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatesToAttributes_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealEstatesToAttributes_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    RealEstateId = table.Column<int>(nullable: false),
                    ExpediaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalSchema: "Accommodation",
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizedRooms",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizedRooms", x => new { x.Id, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LocalizedRooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalizedRooms_Rooms_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalizedRooms_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Localization",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotosToRooms",
                schema: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ToId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "GetUtcDate()"),
                    CreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotosToRooms", x => new { x.Id, x.ToId });
                    table.ForeignKey(
                        name: "FK_PhotosToRooms_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotosToRooms_Photos_Id",
                        column: x => x.Id,
                        principalSchema: "Accommodation",
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotosToRooms_Rooms_ToId",
                        column: x => x.ToId,
                        principalSchema: "Accommodation",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "5abb44c9-726b-40ad-a7c3-2cbc80d6aac5", null, false, false, null, null, null, null, null, false, null, false, "TravelDbContext" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 1, 1, "AmenityOfAccommodation" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 2, 1, "AmenityOfRoom" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 3, 1, "CheckInOut" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 4, 1, "Other" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 5, 1, "Payment" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeSubtypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 6, 1, "Pets" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeTypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 1, 1, "Amenity" });

            migrationBuilder.InsertData(
                schema: "Accommodation",
                table: "AttributeTypes",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 2, 1, "Policy" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 10, 1, "Point of Interest Shadow", "PointOfInterestShadow" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 9, 1, "Point of Interest", "PointOfInterest" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 8, 1, "Neighborhood", "Neighborhood" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 7, 1, "City", "City" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 6, 1, "Multi-City (Vicinity)", "MultiCity" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 2, 1, "Continent", "Continent" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 4, 1, "Province (State)", "Province" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 3, 1, "Country", "Country" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 11, 1, "Airport", "Airport" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 1, 1, "World", "World" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 5, 1, "Multi-Region (within a country)", "MultiRegion" });

            migrationBuilder.InsertData(
                schema: "Geography",
                table: "Subtypes",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[] { 12, 1, "Train Station", "TrainStation" });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_CreatorId",
                schema: "Accommodation",
                table: "Attributes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_SubtypeId",
                schema: "Accommodation",
                table: "Attributes",
                column: "SubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_TypeId",
                schema: "Accommodation",
                table: "Attributes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSubtypes_CreatorId",
                schema: "Accommodation",
                table: "AttributeSubtypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeTypes_CreatorId",
                schema: "Accommodation",
                table: "AttributeTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Captions_CreatorId",
                schema: "Accommodation",
                table: "Captions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_CreatorId",
                schema: "Accommodation",
                table: "Descriptions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_Name",
                schema: "Accommodation",
                table: "Descriptions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chains_CreatorId",
                schema: "Accommodation",
                table: "Chains",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Chains_ExpediaId",
                schema: "Accommodation",
                table: "Chains",
                column: "ExpediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedAttributes_CreatorId",
                schema: "Accommodation",
                table: "LocalizedAttributes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedAttributes_LanguageId",
                schema: "Accommodation",
                table: "LocalizedAttributes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedCaptions_CreatorId",
                schema: "Accommodation",
                table: "LocalizedCaptions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedCaptions_LanguageId",
                schema: "Accommodation",
                table: "LocalizedCaptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptions_CreatorId",
                schema: "Accommodation",
                table: "LocalizedDescriptions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptions_DescriptionId",
                schema: "Accommodation",
                table: "LocalizedDescriptions",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedDescriptions_LanguageId",
                schema: "Accommodation",
                table: "LocalizedDescriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRealEstates_CreatorId",
                schema: "Accommodation",
                table: "LocalizedRealEstates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRealEstates_LanguageId",
                schema: "Accommodation",
                table: "LocalizedRealEstates",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRealEstateTypes_CreatorId",
                schema: "Accommodation",
                table: "LocalizedRealEstateTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRealEstateTypes_LanguageId",
                schema: "Accommodation",
                table: "LocalizedRealEstateTypes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRooms_CreatorId",
                schema: "Accommodation",
                table: "LocalizedRooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRooms_LanguageId",
                schema: "Accommodation",
                table: "LocalizedRooms",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CaptionId",
                schema: "Accommodation",
                table: "Photos",
                column: "CaptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CreatorId",
                schema: "Accommodation",
                table: "Photos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_FileExtensionId",
                schema: "Accommodation",
                table: "Photos",
                column: "FileExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RealEstateId",
                schema: "Accommodation",
                table: "Photos",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PathToPhotoId_FileName_FileExtensionId",
                schema: "Accommodation",
                table: "Photos",
                columns: new[] { "PathToPhotoId", "FileName", "FileExtensionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhotosToRooms_CreatorId",
                schema: "Accommodation",
                table: "PhotosToRooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosToRooms_ToId",
                schema: "Accommodation",
                table: "PhotosToRooms",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_AirportId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_ChainId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CountryId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_CreatorId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_ExpediaId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "ExpediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstates_TypeId",
                schema: "Accommodation",
                table: "RealEstates",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatesToAttributes_CreatorId",
                schema: "Accommodation",
                table: "RealEstatesToAttributes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatesToAttributes_LanguageId",
                schema: "Accommodation",
                table: "RealEstatesToAttributes",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTypes_CreatorId",
                schema: "Accommodation",
                table: "RealEstateTypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTypes_ExpediaId",
                schema: "Accommodation",
                table: "RealEstateTypes",
                column: "ExpediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CreatorId",
                schema: "Accommodation",
                table: "Rooms",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RealEstateId",
                schema: "Accommodation",
                table: "Rooms",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Code",
                schema: "Geography",
                table: "Airports",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_CreatorId",
                schema: "Geography",
                table: "Airports",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Id",
                schema: "Geography",
                table: "Airports",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continents_Code",
                schema: "Geography",
                table: "Continents",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Continents_CreatorId",
                schema: "Geography",
                table: "Continents",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Continents_Id",
                schema: "Geography",
                table: "Continents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Code",
                schema: "Geography",
                table: "Countries",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatorId",
                schema: "Geography",
                table: "Countries",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id",
                schema: "Geography",
                table: "Countries",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_CreatorId",
                schema: "Geography",
                table: "LocalizedRegions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizedRegions_LanguageId",
                schema: "Geography",
                table: "LocalizedRegions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CreatorId",
                schema: "Geography",
                table: "Regions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_SubtypeId",
                schema: "Geography",
                table: "Regions",
                column: "SubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionToRegions_CreatorId",
                schema: "Geography",
                table: "RegionToRegions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionToRegions_ToId",
                schema: "Geography",
                table: "RegionToRegions",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionToSubclasss_CreatorId",
                schema: "Geography",
                table: "RegionToSubclasss",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionToSubclasss_ToId",
                schema: "Geography",
                table: "RegionToSubclasss",
                column: "ToId");

            migrationBuilder.CreateIndex(
                name: "IX_SubClasses_CreatorId",
                schema: "Geography",
                table: "SubClasses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubClasses_Name",
                schema: "Geography",
                table: "SubClasses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtypes_CreatorId",
                schema: "Geography",
                table: "Subtypes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subtypes_Description",
                schema: "Geography",
                table: "Subtypes",
                column: "Description",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subtypes_Name",
                schema: "Geography",
                table: "Subtypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileExtensions_CreatorId",
                schema: "IO",
                table: "FileExtensions",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FileExtensions_Extension",
                schema: "IO",
                table: "FileExtensions",
                column: "Extension",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PathsToPhotos_CreatorId",
                schema: "IO",
                table: "PathsToPhotos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PathsToPhotos_Path",
                schema: "IO",
                table: "PathsToPhotos",
                column: "Path",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatorId",
                schema: "Localization",
                table: "Languages",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ExpediaCode",
                schema: "Localization",
                table: "Languages",
                column: "ExpediaCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalizedAttributes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "LocalizedCaptions",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "LocalizedDescriptions",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "LocalizedRealEstates",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "LocalizedRealEstateTypes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "LocalizedRooms",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "PhotosToRooms",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "RealEstatesToAttributes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Continents",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "LocalizedRegions",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "RegionToRegions",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "RegionToSubclasss",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RolesClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UsersTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Descriptions",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Photos",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Localization");

            migrationBuilder.DropTable(
                name: "SubClasses",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "Captions",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "FileExtensions",
                schema: "IO");

            migrationBuilder.DropTable(
                name: "PathsToPhotos",
                schema: "IO");

            migrationBuilder.DropTable(
                name: "RealEstates",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "AttributeSubtypes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "AttributeTypes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Airports",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "Chains",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "RealEstateTypes",
                schema: "Accommodation");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "Subtypes",
                schema: "Geography");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Identity");
        }
    }
}
