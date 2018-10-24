namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class PhotoOfAccommodationToTypeOfRoom : ManyToMany
    {
        public PhotoOfAccommodation PhotoOfAccommodation { get; set; }
        public TypeOfRoom TypeOfRoom { get; set; }
    }
}