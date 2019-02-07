﻿using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Object;

namespace Olbrasoft.Travel.Data.Queries
{
    public class AccommodationDetailByAccommodationIdAndLanguageIdQuery : ByAccommodationIdAndLanguageIdQuery<AccommodationDetail>
    {
        public AccommodationDetailByAccommodationIdAndLanguageIdQuery(IProvider queryProvider) : base(queryProvider)
        {
        }
    }
}