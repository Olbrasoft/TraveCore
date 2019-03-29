using Olbrasoft.Data;
using Olbrasoft.Travel.Data.Base;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Data.Localization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Accommodation
{
    /// <summary>
    /// Represents a description in a particular language
    /// </summary>
    public class DescriptionTranslation : IHaveLanguageId, IHaveDateAndTimeOfCreation
    {
        public int DescriptionId { get; set; }

        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        public int LanguageId { get; set; }

        [Required]
        public string Text { get; set; }

        public int CreatorId { get; set; }

        public DateTime Created { get; set; }

        public virtual Property Property { get; set; }

        public virtual Description Description { get; set; }

        public virtual Language Language { get; set; }

        public User Creator { get; set; }
    }
}