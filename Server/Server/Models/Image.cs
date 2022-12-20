using System.ComponentModel.DataAnnotations;
namespace Server.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}
