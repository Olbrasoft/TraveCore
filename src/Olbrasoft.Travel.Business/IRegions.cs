using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Business
{
    public interface IRegions
    {
        Task<IEnumerable<ContinentItem>> GetContinentsAsync(int languageId, CancellationToken token = default);

        Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int languageId, CancellationToken token = default);

        Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int continentId, int languageId, CancellationToken token = default);

        Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] term, int languageId, CancellationToken token = default);

        Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int languageId, CancellationToken token = default);
    }
};