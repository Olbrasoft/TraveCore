using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Queries.Geography;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Geography;

namespace Olbrasoft.Travel.Business.Services
{
    public class RegionService : Olbrasoft.Business.Service, IRegions
    {
        public RegionService(IQueryFactory queryFactory) : base(queryFactory)
        {
        }

        public Task<IEnumerable<ContinentItem>> GetContinentsAsync(int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<ContinentsByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<CountriesByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<CountryItemDto>> GetCountriesAsync(int continentId, int languageId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<CountriesByContinentIdAndLanguageIdQuery>();
            query.ContinentId = continentId;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<SuggestionDto>> SuggestionsAsync(string[] term, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<RegionsSuggestionsByTermAndLanguageIdQuery>();
            query.Terms = term;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

       
    }
}