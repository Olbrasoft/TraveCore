using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;
using System.Collections.Generic;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveAttributes
    {
        IEnumerable<AttributeDto> Attributes { get; set; }
    }
}