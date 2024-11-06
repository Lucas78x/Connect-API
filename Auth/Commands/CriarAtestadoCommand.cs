using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Commands
{
    public class CriarAtestadoCommand : IRequest<AtestadoDTO>
    {
        public AtestadoDTO Atestado { get; set; }

        public CriarAtestadoCommand(AtestadoDTO atestado)
        {
           Atestado = atestado;
        }
    }
}
