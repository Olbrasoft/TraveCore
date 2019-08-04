using Olbrasoft.Travel.Data.Transfer.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Business
{
    public class TravelFacade : ITravel
    {
        public IRegions Regions { get; }
        public IProperties Properties { get; }

        public TravelFacade(IRegions regions, IProperties properties)
        {
            Regions = regions;
            Properties = properties;
        }

        public async Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int languageId, CancellationToken cancellationToken = default)
        {
            //var terms = term.Trim().Split(' ');

            var results = await Task.WhenAll(Regions.SuggestionsAsync(term, languageId, cancellationToken),
                Properties.SuggestionsAsync(term, languageId, cancellationToken)).ConfigureAwait(false);

            return results.SelectMany(result => result).OrderBy(p => p.CategoryId);

            //  return await Properties.SuggestionsAsync(terms, languageId, cancellationToken);
        }
    }
}