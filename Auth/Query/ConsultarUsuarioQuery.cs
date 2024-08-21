using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarUsuarioQuery : IRequest<LoginDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public ConsultarUsuarioQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
