using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public class SubscribersRepository: ISubscribersRepository
    {
        public List<Subscriptions> GetAllSubsribers(string cookie)
        {
            List<Subscriptions> subs;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                try
                {
                    var userId = db.Users.ToList().Where(x => x.PasswordHash == cookie).SingleOrDefault().Id;
                    subs = db.Subscriptions.ToList().Where(x => x.UserId == userId).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
            return subs;
        }

        public Subscriptions GetSubsriber(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var userId = db.Users.ToList().Where(x => x.PasswordHash == cookie).SingleOrDefault().Id;
                var subs = db.Subscriptions.ToList().Where(u => u.UserId == userId && u.SecondUserId == id).SingleOrDefault();
                return subs;
            }
        }

        public async Task<int> AddSubsriber(Subscriptions sub, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var subs = db.Subscriptions.ToList();
                foreach (Subscriptions s in subs)
                    if (s.UserId == sub.UserId && s.SecondUserId == sub.SecondUserId)
                        return -1;
                db.Subscriptions.Add(sub);
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public async Task<int> DeleteSubsriber(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var us = db.Users.ToList().Where(_ => _.PasswordHash == cookie).SingleOrDefault().Id;
                var sub = db.Subscriptions.ToList().Where(x => x.UserId == us && x.SecondUserId == id).SingleOrDefault();
                
                try
                {
                    db.Subscriptions.Remove(sub);
                    await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }
    }
}
