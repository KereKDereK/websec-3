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

        public async Task<int> AddUser(int user)
        {
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
                return -1;
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
                return -1;
            }

            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Users.Add(user_to_add);
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
