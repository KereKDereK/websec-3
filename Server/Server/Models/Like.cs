using Microsoft.EntityFrameworkCore;
namespace Server.Models
{   
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public Like(int id, int postId, int userId)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
        }
    }
}
