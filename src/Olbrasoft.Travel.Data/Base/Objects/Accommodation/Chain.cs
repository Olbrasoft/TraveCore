using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class Chain : OwnerCreatorInfoAndCreator, IHaveExpediaId<int>, IHaveName
    {
        public int ExpediaId { get; set; } = int.MinValue;

        public string Name { get; set; }

        public virtual ICollection<Property> Accommodations { get; set; }
    }
}