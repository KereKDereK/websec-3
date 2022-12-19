using System.ComponentModel.DataAnnotations;
using System;

namespace Server.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime DateComment { get; set; }
        public Comment(int commentId, int postId, string commentText, int userId, DateTime dateComment)
        {
            Id = commentId;
            PostId = postId;
            CommentText = commentText;
            UserId = userId;
            DateComment = dateComment;
        }

        public Comment(int postId, string commentText, int userId, DateTime dateComment)
        {
            PostId = postId;
            CommentText = commentText;
            UserId = userId;
            DateComment = dateComment;
        }
    }
}
