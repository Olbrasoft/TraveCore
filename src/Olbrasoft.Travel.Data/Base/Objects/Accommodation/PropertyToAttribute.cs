using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base.Objects.Identity;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class PropertyToAttribute : IHaveDateAndTimeOfCreation
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Real%20estate%20to%20Attribute
    {
        [Key]
        [Column(Order = 1)]
        public int PropertyId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AttributeId { get; set; }

        [Key]
        [Column(Order = 3)]
        public int LanguageId { get; set; }

        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }

        [MaxLength(800)]
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public User Creator { get; set; }

        public Property Property { get; set; }

        public Attribute Attribute { get; set; }

        public Language Language { get; set; }
    }
}