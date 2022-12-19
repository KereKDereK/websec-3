namespace Server.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RegistrationType { get; set; }
        public User(int userId, string userName,string email, string passwordHash, int registrationType)
        {
            UserId = userId;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            RegistrationType = registrationType;    
        }

    }
}
