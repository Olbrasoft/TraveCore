using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Base.Objects.Geography
{
    public class Airport : ExpandingInformationAboutRegion
    {
        public ICollection<Property> Accommodations { get; set; }
    }
}