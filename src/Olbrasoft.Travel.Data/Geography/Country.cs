using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Geography
{
    public class Country : ExpandingInformationAboutRegion
    {
        //todo change https://en.wikipedia.org/wiki/ISO_3166-1

        public virtual ICollection<Property> Accommodations { get; set; }
    }
    
}