using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Data.Mapping;
using Olbrasoft.Travel.Data.Accommodation;
using Olbrasoft.Travel.Data.Queries.Accommodation;
using Olbrasoft.Travel.Data.Transfer.Objects;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.QueryHandlers.Accommodation
{
    public class RealEstatesSuggestionsQueryHandler : TravelQueryHandler<RealEstatesSuggestionsQuery, LocalizedRealEstate, IEnumerable<SuggestionDto>>
    {
        public override async Task<IEnumerable<Transfer.Objects.SuggestionDto>> HandleAsync(RealEstatesSuggestionsQuery query, CancellationToken cancellationToken)
        {
            //var termsWhere = new StringBuilder();
            //termsWhere.Append("(");
            //var termsCount = query.Terms.Length;

            //foreach (var term in query.Terms)
            //{
            //    termsCount--;
            //    termsWhere.Append($"(Name LIKE N'{term}%')");
            //    if (termsCount > 0) termsWhere.Append("OR");
            //}

            //termsWhere.Append(")");

            //var q = Context.Set<LocalizedRealEstate>().FromSql($"Select Top(3) * From Accommodation.LocalizedRealEstate WHERE ( LanguageId = {query.LanguageId}) AND  {termsWhere}");

            // var sq = $"Select Top(3) * From Accommodation.LocalizedRealEstates WHERE (LanguageId = {1033}) AND " + termsWhere.ToString();

            //var q = Context.Set<LocalizedRealEstate>().FromSql(sq);

            //  q = query.Terms.Aggregate(q, (current, term) => current.Where(p => p.Name.StartsWith(term)));

            //return await q.ToArrayAsync(cancellationToken);

            //var result = from r in q
            //             select new SuggestionDto
            //             {
            //                 Id = r.Id,
            //                 Label = r.Name
            //             };

            //q = q.Where(p => p.Name.Contains( query.Terms));
            //return await result.ToArrayAsync(cancellationToken);
            // define the optimizer you want to use
            //            var optimizer = ExpressionOptimizer;

            var q = Source.Where(p => p.LanguageId == query.LanguageId);

            var predicate = query.Terms.Aggregate(PredicateBuilder.New<LocalizedRealEstate>(), (current, term) => current.Or(p => p.Name.Contains(term)));

            // q = query.Terms.Aggregate(q, (current, t) => current.Where(localizedRealEstate => localizedRealEstate.Name.IndexOf(t, System.StringComparison.OrdinalIgnoreCase) >= 0));

            return await ProjectTo<Transfer.Objects.SuggestionDto>(q.Where(predicate).Take(3)).ToArrayAsync(cancellationToken).ConfigureAwait(false);
        }

        public RealEstatesSuggestionsQueryHandler(TravelDbContext context, IProjection projector) : base(context, projector)
        {
        }
    }
}