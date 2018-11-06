using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Entity.Globalization;


namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public class LocalizedAccommodationByIdQuery : ILocalizedAccommodationByIdQuery
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }

        public LocalizedAccommodation Execute()
        {
            throw new System.NotImplementedException();
        }

        public Task<LocalizedAccommodation> ExecuteAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
