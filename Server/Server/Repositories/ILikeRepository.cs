using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ILikeRepository
    {
        public int AddLike(Like like, string cookie);
        public int DeleteLike(int id, string cookie);
        Like GetLike(int id, string cookie);
        public List<Like> GetAllLikes(string cookie);
    }
}
