using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveAttributes
    {
        IEnumerable<Attribute> Attributes { get; set; }

    }
}