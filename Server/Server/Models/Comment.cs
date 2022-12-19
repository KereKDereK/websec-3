using System;

namespace Server.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime DateComment { get; set; }
        public Comment(int commentId, int postId, string commentText, int userId, DateTime dateComment)
        {
            CommentId = commentId;
            PostId = postId;
            CommentText = commentText;
            UserId = userId;
            DateComment = dateComment;
        }
    }
}
