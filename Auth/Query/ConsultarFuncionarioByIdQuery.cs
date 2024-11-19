using Connect.Auth.DTO;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarFuncionarioByIdQuery : IRequest<FuncionarioDTO>
    {
        public Guid Id { get; set; }
        public ConsultarFuncionarioByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
