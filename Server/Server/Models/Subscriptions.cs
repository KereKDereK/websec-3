using System.ComponentModel.DataAnnotations;
namespace Server.Models
{
    public class Subscriptions
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int SecondUserId { get; set; }
        public User SecondUser { get; set; }
    }
}
