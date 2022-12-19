using Server.Models;
using System.Collections.Generic;
namespace Server.Repository
{
    public interface IUsersRepository
    {
        int AddUser(User user);
        int UpdateUser(User user);
        User GetUserFrId(int id);
        User GetUserFrHash(string hash);
        List<User> GetAllUsers();
        int RemoveUser(int id);
        int RemoveAllUsers();
    }
}
