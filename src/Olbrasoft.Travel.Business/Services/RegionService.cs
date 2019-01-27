using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Data.Queries;
using Olbrasoft.Travel.Data.Queries;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Business.Services
{
    public class RegionService : Olbrasoft.Business.Service, IRegions
    {
        public RegionService(IProvider queryProvider) : base(queryProvider)
        {
        }

        public Task<IEnumerable<ContinentItem>> GetContinentsAsync(int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var query = QueryProvider.Create<ContinentsByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<CountryItem>> GetCountriesAsync(int languageId, CancellationToken cancellationToken = default(CancellationToken))
        { 
            var query = QueryProvider.Create<CountriesByLanguageIdQuery>();
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }

        public Task<IEnumerable<CountryItem>> GetCountriesAsync(int continentId, int languageId,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            var query = QueryProvider.Create<CountriesByContinentIdAndLanguageIdQuery>();
            query.ContinentId = continentId;
            query.LanguageId = languageId;

            return query.ExecuteAsync(cancellationToken);
        }
    }
}