using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Olbrasoft.Travel.Data.Base.Objects.Localization;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    /// <summary>
    /// Represents a description in a particular language
    /// </summary>
    public class DescriptionTranslation : Translation
    {
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual Property Property { get; set; }

        public virtual Description Description { get; set; }
    }
}