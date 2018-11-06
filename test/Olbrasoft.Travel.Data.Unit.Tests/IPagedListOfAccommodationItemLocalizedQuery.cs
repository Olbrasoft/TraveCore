using Olbrasoft.Collections.Generic;
using Olbrasoft.Data.Unit.Tests;
using Olbrasoft.Travel.Data.Entity.Globalization;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Unit.Tests
{
    public interface IPagedListOfAccommodationItemLocalizedQuery : ILocalizedQuery<IPagedList<AccommodationItem>>, IPagedQuery<LocalizedAccommodation, IPagedList<AccommodationItem>>
    {
    }
}