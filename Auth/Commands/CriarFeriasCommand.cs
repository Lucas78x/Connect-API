using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Commands
{
    public class CriarFeriasCommand : IRequest<int?>
    {
        public FeriasModel Ferias { get; set; }

        public CriarFeriasCommand(FeriasModel ferias)
        {
            Ferias = ferias;
        }
    }
}
