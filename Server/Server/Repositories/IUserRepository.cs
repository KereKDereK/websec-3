using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public int AddUser(User user);
        public int UpdateUser(int id, User newUser);
        public int DeleteUser(int id);
        //public int DeleteAllUsers();
        User GetUser(int id);
        public List<User> GetAllUsers();
        public List<Subscriptions> GetSubscriptions(int id);
        public List<Subscriptions> GetSubs(int id);
    }
}
