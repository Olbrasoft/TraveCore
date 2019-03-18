using Microsoft.EntityFrameworkCore;
using Olbrasoft.Travel.Data.Identity;
using Olbrasoft.Travel.Data.Repositories;

namespace Olbrasoft.Travel.Data.EntityFrameworkCore.Repositories
{
    public class UsersRepository : TravelRepository<User>, IUsersRepository
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

        public UsersRepository(DbContext context) : base(context)
        {
        }
    }
}