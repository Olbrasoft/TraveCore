using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Business
{
    public interface ITravel
    {
        IRegions Regions { get; }

        IProperties Properties { get; }

        Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int language, CancellationToken token = default);
    }
}