using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class PhotoToRoom : ManyToMany
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Photo%20To%20Room
    {
        public Photo Photo { get; set; }
        public Room Room { get; set; }
    }
}