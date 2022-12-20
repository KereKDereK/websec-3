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
                var subs = db.Subscriptions.ToList().Where(x => x.Id == id);
                if (subs.Count() == 0)
                    throw new Exception("No element with such ID");
                return (Subscriptions)subs;
            }
        }

        public int AddSubsriber(Subscriptions sub)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Subscriptions.Add(sub);
                try
                {
                    db.SaveChangesAsync();
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
                var sub = (Subscriptions)db.Subscriptions.ToList().Where(x => x.Id == id);
                db.Subscriptions.Remove(sub);
                try
                {
                    db.SaveChangesAsync();
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
