using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                Models.User user1 = new Models.User(1, "Tom", "sobaka@sobaka.com", "123", "1");
                Models.User user2 = new Models.User(2, "Bob", "sobaka2@sobaka.com", "321", "1");

                db.Users.AddRange(user1, user2);
                db.SaveChanges();
            }*/

            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var users = db.Users.Include(u => u.Sub).ToList();
                Console.WriteLine("Список объектов:");
                foreach (Models.User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.UserName} - {u.Email}");
                    foreach (Models.Subscriptions l in u.Sub)
                        Console.WriteLine($"{l.UserId}, {l.SecondUserId}");
                }
            }
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
