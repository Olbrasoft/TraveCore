using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Entity.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class PropertyDatabaseContext : TravelDatabaseContext, IPropertyContext
    {
        public DbSet<TypeOfAccommodation> TypesOfAccommodations { get; set; }
    }
}