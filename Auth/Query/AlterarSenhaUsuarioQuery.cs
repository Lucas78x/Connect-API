using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Query
{
    public class AlterarSenhaUsuarioQuery : IRequest<ChangePasswordModel>
    {
        public ChangePasswordModel  ChangePassword { get; set; }
        public AlterarSenhaUsuarioQuery(ChangePasswordModel changePassword) 
        {
           ChangePassword = changePassword;
        }
    }
}
