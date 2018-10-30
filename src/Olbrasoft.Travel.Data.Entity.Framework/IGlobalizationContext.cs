using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Globalization;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface IGlobalizationContext : ITravelContext
    {
        DbSet<Language> Languages { get; set; }
        DbSet<LocalizedRegion> LocalizedRegions { get; set; }
        DbSet<LocalizedTypeOfAccommodation> LocalizedTypesOfAccommodations { get; set; }
        DbSet<LocalizedAccommodation> LocalizedAccommodations { get; set; }
        DbSet<LocalizedDescriptionOfAccommodation> LocalizedDescriptionsOfAccommodations { get; set; }
        DbSet<LocalizedCaption> LocalizedCaptions { get; set; } 
        DbSet<LocalizedTypeOfRoom> LocalizedTypesOfRooms { get; set; }
        //DbSet<LocalizedAttribute> LocalizedAttributes { get; set; }
        //DbSet<AccommodationToAttribute> AccommodationsToAttributes { get; set; }
    }
}