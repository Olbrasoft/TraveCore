using System;

namespace Olbrasoft.Travel.Data.Entity.Globalization
{
    public class LocalizedDescriptionOfAccommodation : ILocalized, IHaveDateTimeOfCreation
    {
        public int AccommodationId { get; set; }

        public int TypeOfDescriptionId { get; set; }

        public int LanguageId { get; set; }

        public string Text { get; set; }

        public int CreatorId { get; set; }

        public DateTime DateAndTimeOfCreation { get; set; }

       // public virtual Accommodation Accommodation { get; set; }

      //  public virtual TypeOfDescription TypeOfDescription { get; set; }

        public virtual Language Language { get; set; }

        public Identity.User Creator { get; set; }
    }
}