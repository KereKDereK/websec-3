namespace Server.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int PostId { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }

        public Image(int imageId, int postId, string imageUrl, int order)
        {
            ImageId = imageId;
            PostId = postId;
            ImageUrl = imageUrl;
            Order = order;
        }
    }
}
