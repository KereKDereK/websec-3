using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Server.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string RegistrationType { get; set; }
        public List<Post> Posts { get; set; }
        public List<Like> Likes { get; set; }
        public List<Subscriptions> Subber { get; set; }
        public List<Subscriptions> Sub { get; set; }
    }
}
