using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarUsuarioQuery : IRequest<LoginDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ConsultarUsuarioQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
