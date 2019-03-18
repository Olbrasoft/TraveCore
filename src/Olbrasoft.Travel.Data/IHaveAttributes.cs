using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveAttributes
    {
        IEnumerable<Attribute> Attributes { get; set; }
    }
}