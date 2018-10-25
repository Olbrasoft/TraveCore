namespace Olbrasoft.Travel.Data.Repository
{
    public interface IUsersRepository : IBaseRepository<Entity.Identity.User>
    {
        Entity.Identity.User AddIfNotExist(Entity.Identity.User user);
    }
}