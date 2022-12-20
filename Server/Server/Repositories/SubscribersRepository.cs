using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class SubscribersRepository: ISubscribersRepository
    {
        public List<Subscriptions> GetAllSubsribers()
        {
            List<Subscriptions> subs;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                subs = db.Subscriptions.ToList();
            }
            return subs;
        }

        public Subscriptions GetSubsriber(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var subs = db.Subscriptions.Find(id);
                return subs;
            }
        }

        public int AddSubsriber(Subscriptions sub)
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
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return -1;
                }
            }
            return 1;
        }

        public int DeleteSubsriber(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var sub = db.Subscriptions.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Subscriptions.Remove(sub);
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
    }
}
