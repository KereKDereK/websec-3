using Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories
{
    public interface ILikeRepository
    {
        public Task<int> AddLike(Like like, string cookie);
        public Task<int> DeleteLike(int id, string cookie);
        Task<Like> GetLike(int id, string cookie);
        public List<Like> GetAllLikes(string cookie);
    }
}
