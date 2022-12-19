namespace Server.Models
{
    public class Like
    {
        public int LikeId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Like(int likeId, int postId, int userId)
        {
            LikeId = likeId;
            PostId = postId;
            UserId = userId;
        }
    }
}
