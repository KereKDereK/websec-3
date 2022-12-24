using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Server.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        public List<Comment> GetAllComments(string cookie)
        {
            List<Comment> comments;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                comments = db.Comments.ToList();
            }
            return comments;
        }

        public Comment GetComment(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.Find(id);
                return comment;
            }
        }

        public int AddComment(Comment comment, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                comment.Name = db.Users.Find(comment.UserId).UserName;
                db.Comments.Add(comment);
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

        public int UpdateComment(int id, Comment newComment, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.ToList().Where(x => x.Id == id).SingleOrDefault();
                comment.Text = newComment.Text;
                comment.Datetime = newComment.Datetime;
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

        public int DeleteComment(int id, string cookie)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.ToList().Where(x => x.Id == id).SingleOrDefault();
                db.Comments.Remove(comment);
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
