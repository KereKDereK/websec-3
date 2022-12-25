using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public Task<Tuple<int, string>> AddUser(int user, string cookie);
        public int UpdateUser(int id, User newUser, string cookie);
        public int DeleteUser(int id, string cookie);
        Tuple<List<Post>, int> GetUser(int id, string cookie);
        public List<User> GetAllUsers(string cookie);
        public List<Subscriptions> GetSubscriptions(int id, string cookie);
        public List<Subscriptions> GetSubs(int id, string cookie);
    }
}
