using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Business
{
    public interface ITravel
    {
        IRegions Regions { get; }

        IAccommodations Accommodations { get; }

        Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int languageId, CancellationToken cancellationToken = default(CancellationToken));
    }
}