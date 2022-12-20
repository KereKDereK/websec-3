using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mail;

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
            try
            {
                MailAddress checker = new MailAddress(user.Email);
            }
            catch
            {
                return -1;
            }
            var client_id = "9ad6adf4562c48399e6da3cc61272b92";
            var client_secret = "09a0e5e772f24177b672822239237660";
            var url = "https://oauth.yandex.ru/token";

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
            try
            {
                MailAddress checker = new MailAddress(newUser.Email);
            }
            catch
            {
                return -1;
            }
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
