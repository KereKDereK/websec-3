using Server.Models;
using System.Collections.Generic;

namespace Server.Repositories
{
    public interface ILikeRepository
    {
        public int AddLike(Like like);
        public int DeleteLike(int id);
        Like GetLike(int id);
        public List<Like> GetAllLikes();
    }
}
