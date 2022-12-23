using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Server.Repositories
{
    public class UserRepository: IUserRepository
    {
        public List<User> GetAllUsers(string cookie)
        {
            List<User> users;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                users = db.Users.ToList();
            }
            return users;
        }

        public User GetUser(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var checker = db.Users.ToList().Where(x => x.Id.ToString() == cookie);
                if (checker.Count() <= 0)
                    throw new Exception("ex");
                else if (checker.SingleOrDefault().Id != id)
                    throw new Exception("ex");
            }
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Find(id);
                return user;
            }
        }

        public async Task<Tuple<int, string>> AddUser(int user, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                if (db.Users.ToList().Where(x => x.Id.ToString() == cookie).Count() >= 1)
                    return new Tuple<int, string> (1, cookie);
            }
            var client_id = "9ad6adf4562c48399e6da3cc61272b92";
            var client_secret = "09a0e5e772f24177b672822239237660";
            var url = "https://oauth.yandex.ru/token";
            var url2 = "https://login.yandex.ru/info?format=json";

            var formDictionary = new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code" },
                {"code", user.ToString()},
                {"client_id", client_id },
                {"client_secret", client_secret }
            };

            var formContent = new FormUrlEncodedContent(formDictionary);
            HttpClient httpClient = new HttpClient();

            using HttpResponseMessage response = await httpClient.PostAsync(url, formContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Dictionary<string, object> result = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonResponse);
            var token = "string";

            try
            {
                token = result["access_token"].ToString();
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(-1, "fail");
            }


            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("OAuth", token);
            var response2 = await httpClient.GetStringAsync(url2);
            result = JsonSerializer.Deserialize<Dictionary<string, object>>(response2);
            User user_to_add = new User();
            try
            { 
            user_to_add = new User
            {
                Email = result["default_email"].ToString(),
                UserName = result["real_name"].ToString(),
                RegistrationType = "1",
                PasswordHash = result["psuid"].ToString()
            };
            }
            catch(Exception ex)
            {
                return new Tuple<int, string>(-1, "fail");
            }

            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                    if (u.Email == user_to_add.Email)
                        return new Tuple<int, string>(1, u.Id.ToString());
                db.Users.Add(user_to_add);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new Tuple<int, string>(-1, "fail");
                }
            }
            return new Tuple<int, string>(-1, "fail");
        }

        public int UpdateUser(int id, User newUser, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var checker = db.Users.ToList().Where(x => x.Id.ToString() == cookie);
                if (checker.Count() <= 0)
                    throw new Exception("ex");
                else if (checker.SingleOrDefault().Id != id)
                    throw new Exception("ex");
            }

            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.ToList().Where(x => x.Id == id).SingleOrDefault();
                user.UserName = newUser.UserName;
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

        public int DeleteUser(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var checker = db.Users.ToList().Where(x => x.Id.ToString() == cookie);
                if (checker.Count() <= 0)
                    throw new Exception("ex");
                else if (checker.SingleOrDefault().Id != id)
                    throw new Exception("ex");
            }
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

        public List<Subscriptions> GetSubscriptions(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Include(x => x.Subber).ToList().Where(x => x.Id == id).SingleOrDefault();
                return user.Subber;
            }
        }
        public List<Subscriptions> GetSubs(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var user = db.Users.Include(x => x.Sub).ToList().Where(x => x.Id == id).SingleOrDefault();
                return user.Sub;
            }
        }
    }
}
