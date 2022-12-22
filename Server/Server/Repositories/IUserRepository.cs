using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public Task<int> AddUser(int user);
        public int UpdateUser(int id, User newUser);
        public int DeleteUser(int id);
        User GetUser(int id);
        public List<User> GetAllUsers();
        public List<Subscriptions> GetSubscriptions(int id);
        public List<Subscriptions> GetSubs(int id);
    }
}
