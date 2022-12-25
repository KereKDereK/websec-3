using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface IUserRepository
    {
        public Task<Tuple<int, string>> AddUser(int user, string cookie);
        public Task<int> UpdateUser(int id, User newUser, string cookie);
        public Task<int> DeleteUser(int id, string cookie);
        int GetUser(string cookie);
        public List<User> GetAllUsers(string cookie);
        public List<Subscriptions> GetSubscriptions(int id, string cookie);
        public List<Subscriptions> GetSubs(int id, string cookie);
    }
}
