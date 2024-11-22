namespace Connect.Auth.DTO
{
    public class LoginDTO
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool FirstLogin { get; set; }


        public void SetNewPasswordHash(string newPasswordHash)  => PasswordHash = newPasswordHash;
        public void SetFirstLogin(bool firstLogin = true) => FirstLogin = firstLogin;

        public Guid FuncionarioId { get; set; }
        public FuncionarioDTO Funcionario { get; set; }

        public LoginDTO() { }

        public LoginDTO(string email, string passwordHash, FuncionarioDTO funcionario)
                    {
         
            Email = email;
            PasswordHash = passwordHash;
            FuncionarioId = funcionario.Id;
            Funcionario = funcionario;
        }
    }
}
