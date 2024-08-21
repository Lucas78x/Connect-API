using Connect.Auth.Enums;

namespace Connect.Auth.Models
{
    public class RegisterModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        //Funcionario
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public int Genero { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cargo { get; set; }
        public int Permissao { get; set; }

    }
}
