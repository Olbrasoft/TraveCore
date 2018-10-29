using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public interface IPropertyContext : ITravelContext
    {
         DbSet<TypeOfAccommodation> TypesOfAccommodations { get; set; }
         DbSet<Chain> Chains { get; set; }
         DbSet<Property.Accommodation> Accommodations { get; set; }
        //DbSet<TypeOfDescription> TypesOfDescriptions { get; set; }
        //DbSet<Caption> Captions { get; set; }
        //DbSet<PhotoOfAccommodation> PhotosOfAccommodations { get; set; }
        //DbSet<TypeOfRoom> TypesOfRooms { get; set; }
        //DbSet<PhotoOfAccommodationToTypeOfRoom> PhotosOfAccommodationsToTypesOfRooms { get; set; }
        //DbSet<TypeOfAttribute> TypesOfAttributes { get; set; }
        //DbSet<SubTypeOfAttribute> SubTypesOfAttributes { get; set; }
        //DbSet<Attribute> Attributes { get; set; }
    }
}