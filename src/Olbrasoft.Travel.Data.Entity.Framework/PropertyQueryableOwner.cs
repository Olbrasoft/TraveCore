using System.Linq;

namespace Olbrasoft.Travel.Data.Entity.Framework
{
    public class PropertyQueryableOwner<TProperty> : IHavePropertyQueryable<TProperty> where TProperty : class
    {
        public IQueryable<TProperty> Queryable { get; }

        public PropertyQueryableOwner(IPropertyContext context)
        {
            Queryable = context.Set<TProperty>();
        }
    }
}