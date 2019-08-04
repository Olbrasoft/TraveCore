using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    public class Caption : OwnerCreatorInfoAndCreator
    {
        public virtual ICollection<CaptionTranslation> LocalizedCaptions { get; set; }

       // public virtual ICollection<Photo> Photos { get; set; }
    }
}