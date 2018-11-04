using System.Linq;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class GlobalizationQueryableOwner<TGlobalization> :IHaveGlobalizationQueryable<TGlobalization> where TGlobalization : class
    {
        public IQueryable<TGlobalization> Queryable { get; }

        public GlobalizationQueryableOwner(IGlobalizationContext context)
        {
            Queryable = context.Set<TGlobalization>();
        }
    }
}