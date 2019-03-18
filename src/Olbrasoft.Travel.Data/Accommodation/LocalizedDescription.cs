using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Data.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class LocalizedDescription : ILocalized, IHaveDateAndTimeOfCreation
    {
        public int RealEstateId { get; set; }

        public int DescriptionId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        public string Text { get; set; }

        public int CreatorId { get; set; }

        public DateTime Created { get; set; }

        public virtual RealEstate RealEstate { get; set; }

        public virtual Description Description { get; set; }

        public virtual Language Language { get; set; }

        public User Creator { get; set; }
    }
}