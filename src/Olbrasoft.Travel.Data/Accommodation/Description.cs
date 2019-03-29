using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Accommodation
{
    public class Description : HaveName
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Description
    {
        public virtual ICollection<DescriptionTranslation> DescriptionTranslations { get; set; }
    }
}