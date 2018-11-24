using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity.Geography
{
    public class Country : ExpandingInformationAboutRegion
    {
        //todo change https://en.wikipedia.org/wiki/ISO_3166-1

        public virtual ICollection<Property.Accommodation> Accommodations { get; set; }
    }
    
}