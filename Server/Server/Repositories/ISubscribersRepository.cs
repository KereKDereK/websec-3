using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ISubscribersRepository
    {
        public int AddSubsriber(Subscriptions subscriptions, string cookie);
        public int DeleteSubsriber(int id, string cookie);
        Subscriptions GetSubsriber(int id, string cookie);
        public List<Subscriptions> GetAllSubsribers(string cookie);
    }
}
