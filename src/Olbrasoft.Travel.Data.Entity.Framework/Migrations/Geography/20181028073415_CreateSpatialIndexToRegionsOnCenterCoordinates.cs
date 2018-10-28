using Microsoft.EntityFrameworkCore.Migrations;

namespace Olbrasoft.Travel.Data.Entity.Framework.Migrations.Geography
{
    public partial class CreateSpatialIndexToRegionsOnCenterCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE SPATIAL INDEX [IX_Geography_Regions_CenterCoordinates] ON [Geography].[Regions](CenterCoordinates)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX [IX_Geography_Regions_CenterCoordinates] ON [Geography].[Regions]");
        }
    }
}
