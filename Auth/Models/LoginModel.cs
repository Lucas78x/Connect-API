namespace Connect.Auth.Models
{
    public class LoginModel
    {
        public long Id { get; set; }
        public int Genero { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool FirstLogin { get; set; }


        public void SetId(long id) => Id = id;
        public void SetGenero(int genero) => Genero = genero;
        public void SetFirstLogin(bool firstlogin) => FirstLogin = firstlogin;
    }
}
