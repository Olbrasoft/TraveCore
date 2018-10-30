using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class GlobalizationDatabaseContext : TravelDatabaseContext, IGlobalizationContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<LocalizedRegion> LocalizedRegions { get; set; }
        public DbSet<LocalizedTypeOfAccommodation> LocalizedTypesOfAccommodations { get; set; }
        public DbSet<LocalizedAccommodation> LocalizedAccommodations { get; set; }
        public DbSet<LocalizedDescriptionOfAccommodation> LocalizedDescriptionsOfAccommodations { get; set; }
        public DbSet<LocalizedCaption> LocalizedCaptions { get; set; }
    }
}