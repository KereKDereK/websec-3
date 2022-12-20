using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ISubscribersRepository
    {
        public int AddSubsriber(Subscriptions subscriptions);
        public int DeleteSubsriber(int id);
        Subscriptions GetSubsriber(int id);
        public List<Subscriptions> GetAllSubsribers();
    }
}
