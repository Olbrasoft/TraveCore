using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects;

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

        public Task<IEnumerable<CountryItem>> GetCountriesAsync(int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<CountriesByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<CountryItem>> GetCountriesAsync(int continentId, int languageId,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<CountriesByContinentIdAndLanguageIdQuery>();
            query.ContinentId = continentId;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<Suggestion>> SuggestionsAsync(string[] term, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryFactory.Get<RegionsSuggestionsByTermAndLanguageIdQuery>();
            query.Terms = term;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

       
    }
}