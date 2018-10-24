using System.Collections.Generic;

namespace Olbrasoft.Travel.Data.Entity.Property
{
    public class SubTypeOfAttribute : BaseName
    {
        public ICollection<Attribute> Attributes { get; set; }
    }
}