using System;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;
using Olbrasoft.Travel.Data.Base.Objects.Geography;
using Olbrasoft.Travel.Data.Base.Objects.IO;
using Olbrasoft.Travel.Data.Base.Objects.Localization;
using Attribute = Olbrasoft.Travel.Data.Base.Objects.Accommodation.Attribute;

namespace Olbrasoft.Travel.Data.Base.Objects.Identity
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser<int>, IHaveDateAndTimeOfCreation
    {
        //public virtual ICollection<Role> Roles { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// Types of Regions created by the User.
        /// </summary>
        public virtual ICollection<RegionSubtype> RegionSubtypes { get; set; }

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
        /// RegionsTranslations created by the User.
        /// </summary>
        public virtual ICollection<RegionTranslation> LocalizedRegions { get; set; }

        /// <summary>
        /// PropertyTypes created by the User.
        /// </summary>
        public virtual ICollection<PropertyType> PropertyTypes { get; set; }

        /// <summary>
        /// PropertyTypesTranslations created by the User.
        /// </summary>
        public virtual ICollection<PropertyTypeTranslation> PropertyTypesTranslations { get; set; }

        /// <summary>
        /// Chains created by the User.
        /// </summary>
        public virtual ICollection<Chain> Chains { get; set; }

        /// <summary>
        /// Properties created by the User.
        /// </summary>
        public virtual ICollection<Property> Properties { get; set; }

        public virtual ICollection<PropertyTranslation> PropertiesTranslations { get; set; }

        public virtual ICollection<Description> Descriptions { get; set; }

        public virtual ICollection<DescriptionTranslation> DescriptionsTranslations { get; set; }

        /// <summary>
        /// Paths of Photos created by the User
        /// </summary>
        public virtual ICollection<PathToPhoto> PathsOfPhotos { get; set; }

        /// <summary>
        /// Files Extensions created by the User.
        /// </summary>
        public virtual ICollection<FileExtension> FileExtensions { get; set; }

        /// <summary>
        /// Captions created by the User.
        /// </summary>
        public virtual ICollection<Caption> Captions { get; set; }

        /// <summary>
        /// Translation Captions created by the User.
        /// </summary>
        public virtual ICollection<CaptionTranslation> CaptionsTranslations { get; set; }

        /// <summary>
        /// Photos of Properties created by the User.
        /// </summary>
        public virtual ICollection<Photo> Photos { get; set; }

        /// <summary>
        /// Rooms created by the User.
        /// </summary>
        public virtual ICollection<Room> Rooms { get; set; }

        /// <summary>
        /// Translation Types of Rooms created by the User.
        /// </summary>
        public virtual ICollection<RoomTranslation> RoomsTranslations { get; set; }

        /// <summary>
        /// Photos of Properties to Types of Rooms created by the User.
        /// </summary>
        public virtual ICollection<PhotoToRoom> PhotosToRooms { get; set; }

        /// <summary>
        /// Types of Attributes created by the User.
        /// </summary>
        public virtual ICollection<AttributeType> AttributeTypes { get; set; }

        /// <summary>
        /// Sub Types Of Attributes created by the User.
        /// </summary>
        public virtual ICollection<AttributeSubtype> AttributeSubtypes { get; set; }

        /// <summary>
        /// Attributes created by the User.
        /// </summary>
        public virtual ICollection<Attribute> Attributes { get; set; }

        /// <summary>
        /// Translation Attributes created by the User.
        /// </summary>
        public virtual ICollection<AttributeTranslation> AttributesTranslations { get; set; }

        /// <summary>
        /// Properties to Attributes created by the User.
        /// </summary>
        public virtual ICollection<PropertyToAttribute> PropertiesToAttributes { get; set; }

        public ICollection<PropertyToRegion> PropertiesToRegions { get; set; }
    }
}