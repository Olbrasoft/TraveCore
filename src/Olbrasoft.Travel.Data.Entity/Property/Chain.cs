using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class Chain : OwnerCreatorIdAndCreator, IHaveEanId<int>, IHaveName
    {
        public int EanId { get; set; } = int.MinValue;

        public string Name { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}