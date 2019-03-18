using System.Collections.Generic;

namespace Olbrasoft.Travel.Providers.Expedia
{
    public interface IParser<TEan> where TEan : class, new()
    {
        bool TryParse(string line, out TEan entity);
        IEnumerable<TEan> ParseAll(IEnumerable<string> lines);
        TEan Parse(string[] items);
    }
}