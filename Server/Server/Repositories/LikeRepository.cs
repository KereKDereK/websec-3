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
                var like = db.Likes.Find(id);
                return like;
            }
        }

        public int AddLike(Like like)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                db.Likes.Add(like);
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

        public int DeleteLike(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var like = db.Likes.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Likes.Remove(like);
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
