using System.ComponentModel.DataAnnotations;

namespace Olbrasoft.Travel.Data.Transfer.Objects
{
    public abstract class BaseAccommodationDto : IAccommodation
    {
        public int Id { get; set; }

        public decimal StarRating { get; set; }

        [Required]
        [StringLength(70)]
        public string Name { get; set; }

        [StringLength(80)]
        public string Location { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

    }
}