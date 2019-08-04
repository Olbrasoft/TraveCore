using Olbrasoft.Querying;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Travel.Business.Services
{
    public class RegionService : Olbrasoft.Querying.Business.ServiceWithQueryFactory, IRegions
    {
        public RegionService(IQueryFactory queryFactory) : base(queryFactory)
        {
        }

        public Task<IEnumerable<ContinentItem>> GetContinentsAsync(int languageId, CancellationToken token = default(CancellationToken))
        {
            var query = GetQuery<ContinentsByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        public Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int languageId, CancellationToken token = default(CancellationToken))
        {
            var query = GetQuery<CountriesByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        public Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int continentId, int languageId,
            CancellationToken token = default(CancellationToken))
        {
            var query = GetQuery<CountriesByContinentIdAndLanguageIdQuery>();
            query.ContinentId = continentId;
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] term, int languageId, CancellationToken token = default)
        {
            var query = GetQuery<RegionsSuggestionsByTermsTranslationQuery>();
            query.Terms = term;
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string term, int languageId, CancellationToken token = default)
        {
            var query = GetQuery<RegionSuggestionsTranslationQuery>();
            query.Term = term;
            query.LanguageId = languageId;

            return query.ExecuteAsync(token);
        }
    }
}