using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Geography
{
    public partial class CreateSpatialIndexToRegionsOnCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE SPATIAL INDEX [IX_Geography_Regions_Coordinates] ON [Geography].[Regions](Coordinates)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX [IX_Geography_Regions_Coordinates] ON [Geography].[Regions]");
        }
    }
}