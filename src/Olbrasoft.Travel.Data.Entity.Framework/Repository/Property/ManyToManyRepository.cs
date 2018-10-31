using Olbrasoft.Travel.Data.Repository.Property;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Property
{
    public class ManyToManyRepository<TEntity> : OfManyToMany<TEntity>,  IManyToManyRepository<TEntity> where TEntity : ManyToMany 
    {
        protected new IPropertyContext Context { get; }

        public ManyToManyRepository(PropertyDatabaseContext context) : base(context)
        {
            Context = context;
        }
    }
}