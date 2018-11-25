using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Transfer.Object;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Query;

namespace Olbrasoft.Travel.Business.Facade
{
    public class RegionsFacade : Olbrasoft.Business.Facade, IRegions
    {
        public RegionsFacade(IProvider queryProvider) : base(queryProvider)
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
    }
}