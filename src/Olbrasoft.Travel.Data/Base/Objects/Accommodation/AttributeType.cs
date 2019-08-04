using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Base.Objects.Accommodation
{
    [Table(nameof(AttributeType) + "s", Schema = nameof(Accommodation))]
    public class AttributeType : HaveName
    // https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Attribute%20Type
    {
        public ICollection<Attribute> Attributes { get; set; }
    }
}