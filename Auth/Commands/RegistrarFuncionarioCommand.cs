using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Commands
{
    public class RegistrarFuncionarioCommand : IRequest<LoginDTO>
    {
       public LoginDTO Login { get; set; }

        public RegistrarFuncionarioCommand(LoginDTO login)
        {
            Login = login;
        }
    }
}
