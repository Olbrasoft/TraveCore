using Olbrasoft.Data.Query;
using Olbrasoft.Travel.Data.Entity.Globalization;


namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public interface ILocalizedAccommodationByIdQuery : IQuery<LocalizedAccommodation>
    {
        int Id { get; set; }
        int LanguageId { get; set; }
    }
}