using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface ISubscribersRepository
    {
        public Task<int> AddSubsriber(Subscriptions subscriptions, string cookie);
        public Task<int> DeleteSubsriber(int id, string cookie);
        Subscriptions GetSubsriber(int id, string cookie);
        public List<Subscriptions> GetAllSubsribers(string cookie);
    }
}
