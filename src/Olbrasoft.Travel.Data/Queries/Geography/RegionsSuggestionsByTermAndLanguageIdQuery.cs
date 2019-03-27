﻿using System.Collections.Generic;
using Olbrasoft.Data.Querying;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.Queries.Geography
{
    public class RegionsSuggestionsByTermAndLanguageIdQuery : ByLanguageIdQuery<IEnumerable<Transfer.Objects.SuggestionDto>>
    {
        public RegionsSuggestionsByTermAndLanguageIdQuery(IQueryDispatcher queryDispatcher) : base(queryDispatcher)
        {
        }

        public string[] Terms { get; set; }
    }
}