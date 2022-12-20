using System;
using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Repositories
{
    public class LikeRepository: ILikeRepository
    {
        public List<Like> GetAllLikes()
        {
            List<Like> likes;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                likes = db.Likes.ToList();
            }
            return likes;
        }

        public Like GetLike(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = db.Likes.ToList().Where(x => x.Id == id);
                if (like.Count() == 0)
                    throw new Exception("No element with such ID");
                return (Like)like;
            }
        }

        public int AddLike(Like like)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Likes.Add(like);
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

        public int DeleteLike(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = (Like)db.Likes.ToList().Where(x => x.Id == id);
                db.Likes.Remove(like);
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
