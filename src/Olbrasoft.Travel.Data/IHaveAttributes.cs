using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data
{
    public interface IHaveAttributes
    {
        IEnumerable<AttributeDto> Attributes { get; set; }
    }
}