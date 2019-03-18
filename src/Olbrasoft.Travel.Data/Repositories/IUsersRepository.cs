using Olbrasoft.Travel.Data.Identity;

namespace Olbrasoft.Travel.Data.Repositories
{
    public interface IUsersRepository : ITravelRepository<User>
    {
        User AddIfNotExist(User user);
    }
}