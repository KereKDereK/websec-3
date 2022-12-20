using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Repositories
{
    public class UserRepository: IUserRepository
    {
        public List<User> GetAllUsers()
        {
            List<User> users;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                users = db.Users.ToList();
            }
            return users;
        }

        public User GetUser(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }

        public int AddUser(User user)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Users.Add(user);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int UpdateUser(int id, User newUser)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.ToList().Where(x => x.Id == id).SingleOrDefault();
                user.UserName = newUser.UserName;
                user.Email = newUser.Email;
                user.PasswordHash = newUser.PasswordHash;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DeleteUser(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Users.Remove(user);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public List<Subscriptions> GetSubscriptions(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Include(x => x.Subber).ToList().Where(x => x.Id == id).SingleOrDefault();
                return user.Subber;
            }
        }
        public List<Subscriptions> GetSubs(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Include(x => x.Sub).ToList().Where(x => x.Id == id).SingleOrDefault();
                return user.Sub;
            }
        }
    }
}
