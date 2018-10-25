using Olbrasoft.Travel.Data.Entity.Identity;
using Olbrasoft.Travel.Data.Repository;

namespace Olbrasoft.Travel.Data.Entity.Framework.Repository.Identity
{
    public class UsersRepository : IdentityRepository<User>, IUsersRepository
    {
        public User AddIfNotExist(User user)
        {
            var userIn = user;
            var storedUser = Find(u => u.Id == userIn.Id || u.UserName == userIn.UserName);

            if (storedUser == null)
            {
                Add(user);
            }
            else
            {
                user = storedUser;
            }

            return user;
        }

        public UsersRepository(IdentityDatabaseContext context) : base(context)
        {
        }
    }
}