﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Business
{
    public class TravelFacade : ITravel
    {
        public IRegions Regions { get; }
        public IAccommodations Accommodations { get; }

        public TravelFacade(IRegions regions, IAccommodations accommodations)
        {
            Regions = regions;
            Accommodations = accommodations;
        }

        public async Task<IEnumerable<Suggestion>> SuggestionsAsync(string term, int languageId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var terms = term.Split(' ');

            var results = await Task.WhenAll(Regions.SuggestionsAsync(terms, languageId, cancellationToken),
                Accommodations.SuggestionsAsync(terms, languageId, cancellationToken));

            return results.SelectMany(result => result);
        }
    }
}