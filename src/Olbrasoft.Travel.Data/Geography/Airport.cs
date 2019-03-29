using System.Collections.Generic;
using Olbrasoft.Travel.Data.Accommodation;

namespace Olbrasoft.Travel.Data.Geography
{
    public class Airport : ExpandingInformationAboutRegion
    {
        public ICollection<Property> Accommodations { get; set; }
    }
}