using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Geography;
using Olbrasoft.Travel.Data.IO;
using Olbrasoft.Travel.Data.Localization;
using System;
using System.Collections.Generic;
using Attribute = Olbrasoft.Travel.Data.Accommodation.Attribute;

namespace Olbrasoft.Travel.Data.Identity
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser<int>, IHaveDateAndTimeOfCreation
    {
        //public virtual ICollection<Role> Roles { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// Types of Regions created by the User.
        /// </summary>
        public virtual ICollection<Subtype> RegionSubtypes { get; set; }

        /// <summary>
        /// SubClasses created by the User.
        /// </summary>
        public virtual ICollection<Subclass> SubClasses { get; set; }

        /// <summary>
        /// Regions created by the User.
        /// </summary>
        public virtual ICollection<Region> Regions { get; set; }

        /// <summary>
        /// Linking Regions and SubClasses
        /// </summary>
        public virtual ICollection<RegionToSubclass> RegionsToSubclasses { get; set; }

        /// <summary>
        /// Linking Regions To Regions created by the User.
        /// Example Country to Continent or City to Country.
        /// </summary>
        public virtual ICollection<RegionToRegion> RegionsToRegions { get; set; }

        /// <summary>
        /// Countries created by the User.
        /// </summary>
        public virtual ICollection<Country> Countries { get; set; }

        /// <summary>
        /// Continents created by the User.
        /// </summary>
        public virtual ICollection<Continent> Continents { get; set; }

        /// <summary>
        /// Airports created by the User.
        /// </summary>
        public ICollection<Airport> Airports { get; set; }

        /// <summary>
        /// Languages created by the User.
        /// </summary>
        public virtual ICollection<Language> Languages { get; set; }

        /// <summary>
        /// LocalizedRegions created by the User.
        /// </summary>
        public virtual ICollection<LocalizedRegion> LocalizedRegions { get; set; }

        /// <summary>
        /// TypesOfAccommodations created by the User.
        /// </summary>
        public virtual ICollection<RealEstateType> TypesOfAccommodations { get; set; }

        /// <summary>
        /// LocalizedPropertyTypes created by the User.
        /// </summary>
        public virtual ICollection<LocalizedRealEstateType> LocalizedTypesOfAccommodations { get; set; }

        /// <summary>
        /// Chains created by the User.
        /// </summary>
        public virtual ICollection<Chain> Chains { get; set; }

        /// <summary>
        /// Accommodations created by the User.
        /// </summary>
        public virtual ICollection<RealEstate> Accommodations { get; set; }

        /// <summary>
        /// LocalizedRealEstates created by the User.
        /// </summary>
        public virtual ICollection<LocalizedRealEstate> LocalizedAccommodations { get; set; }

        /// <summary>
        /// Types of LocalizedDescriptions created by the User.
        /// </summary>
        public virtual ICollection<Description> AccommodationDescriptions { get; set; }

        /// <summary>
        /// LocalizedDescriptions created by the User.
        /// </summary>
        public virtual ICollection<LocalizedDescription> LocalizedDescriptionsOfAccommodations { get; set; }

        /// <summary>
        /// Paths of Photos created by the User
        /// </summary>
        public virtual ICollection<PathToPhoto> PathsOfPhotos { get; set; }

        /// <summary>
        /// Files Extensions created by the User.
        /// </summary>
        public virtual ICollection<FileExtension> FilesExtensions { get; set; }

        /// <summary>
        /// Captions created by the User.
        /// </summary>
        public virtual ICollection<Caption> Captions { get; set; }

        /// <summary>
        /// Localized Captions created by the User.
        /// </summary>
        public virtual ICollection<LocalizedCaption> LocalizedCaptions { get; set; }

        /// <summary>
        /// Photos of Accommodations created by the User.
        /// </summary>
        public virtual ICollection<Photo> AccommodationPhotos { get; set; }

        /// <summary>
        /// Rooms created by the User.
        /// </summary>
        public virtual ICollection<Room> TypesOfRooms { get; set; }

        /// <summary>
        /// Localized Types of Rooms created by the User.
        /// </summary>
        public virtual ICollection<LocalizedRoom> LocalizedRooms { get; set; }

        /// <summary>
        /// Photos of Accommodations to Types of Rooms created by the User.
        /// </summary>
        public virtual ICollection<PhotoToRoom> PhotosOfAccommodationsToTypesOfRooms { get; set; }

        /// <summary>
        /// Types of Attributes created by the User.
        /// </summary>
        public virtual ICollection<AttributeType> TypesOfAttributes { get; set; }

        /// <summary>
        /// Sub Types Of Attributes created by the User.
        /// </summary>
        public virtual ICollection<AttributeSubtype> SubTypesOfAttributes { get; set; }

        /// <summary>
        /// Attributes created by the User.
        /// </summary>
        public virtual ICollection<Attribute> Attributes { get; set; }

        /// <summary>
        /// Localized Attributes created by the User.
        /// </summary>
        public virtual ICollection<LocalizedAttribute> LocalizedAttributes { get; set; }

        /// <summary>
        /// Accommodations to Attributes created by the User.
        /// </summary>
        public virtual ICollection<RealEstateToAttribute> AccommodationsToAttributes { get; set; }

        public ICollection<SuggestionType> SuggestionTypes { get; set; }

        public ICollection<LocalizedSuggestionType> LocalizedSuggestionTypes { get; set; }
    }
}