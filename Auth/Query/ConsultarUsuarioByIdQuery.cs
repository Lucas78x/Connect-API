using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarUsuarioByIdQuery : IRequest<FuncionarioDTO>
    {
        public long Id { get; set; }
        public ConsultarUsuarioByIdQuery(int id)
        {
            Id = id;
        }
    }
}
