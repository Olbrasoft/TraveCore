﻿using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;
using Olbrasoft.Travel.Data.Transfer.Objects.Accommodation;

namespace Olbrasoft.Travel.Data.Queries.Accommodation
{
    public class RoomsByRealEstateIdAndLanguageIdQuery : ByRealEstateIdAndLanguageIdQuery<IEnumerable<RoomDto>>
    {
        public RoomsByRealEstateIdAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }
    }
}