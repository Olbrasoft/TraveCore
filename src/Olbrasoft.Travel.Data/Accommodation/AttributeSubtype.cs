using Olbrasoft.Travel.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olbrasoft.Travel.Data.Accommodation
{
    [Table(nameof(AttributeSubtype) + "s", Schema = nameof(Accommodation))]
    public class AttributeSubtype : HaveName
    //https://translate.google.cz/#view=home&op=translate&sl=en&tl=cs&text=Attribute%20subtype
    {
        public ICollection<Attribute> Attributes { get; set; }
    }
}