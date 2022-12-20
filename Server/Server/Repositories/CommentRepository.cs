using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Server.Repositories
{
    public class CommentRepository
    {

        public List<Comment> GetAllComments()
        {
            List<Comment> comments;
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                comments = db.Comments.ToList();
            }
            return comments;
        }

        public Comment GetComment(int id)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.Find(id);
                return comment;
            }
        }

        public int AddComment(Comment comment)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
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

        public int UpdateComment(int id, Comment newComment)
        {
            using (Models.ApplicationContext db = new Models.ApplicationContext())
            {
                var comment = db.Comments.ToList().Where(x => x.Id == id).SingleOrDefault();
                comment.CommentText = newComment.CommentText;
                comment.DateComment = newComment.DateComment;
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

        public int DeleteComment(int id)
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
