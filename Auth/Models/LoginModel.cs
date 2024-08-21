namespace Connect.Auth.Models
{
    public class LoginModel
    {
        public long Id { get; set; }
        public int Genero { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}
