using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Providers.Expedia.DataTransfer.Objects.Accommodation
{
    /// <summary>
    /// https://support.ean.com/hc/en-us/articles/115005784325
    /// File Name: PropertyTypeList.txt
    /// Zip File Name: https://www.ian.com/affiliatecenter/include/V2/PropertyTypeList.zip
    /// This is a mapping list of property types for the given Category.
    /// This can be used in conjunction with the ActivePropertyList.
    /// </summary>
    public class PropertyType
    {
        [Key]
        public int Category { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageCode { get; set; }

        [Required]
        [StringLength(256)]
        public string
        CategoryDesc
        { get; set; }
    }
}