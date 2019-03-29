using System.Collections.Generic;
using Olbrasoft.Travel.Data.Base;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Caption : OwnerCreatorInfoAndCreator
    {
        public virtual ICollection<CaptionTranslation> LocalizedCaptions { get; set; }

       // public virtual ICollection<Photo> Photos { get; set; }
    }
}