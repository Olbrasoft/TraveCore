using System.Collections.Generic;

namespace Olbrasoft.Travel.Providers.Expedia
{
    public interface IParser<TExpedia> where TExpedia : class, new()
    {
        bool TryParse(string line, out TExpedia entity);

        IEnumerable<TExpedia> ParseAll(IEnumerable<string> lines);

        TExpedia Parse(string[] items);
    }
}