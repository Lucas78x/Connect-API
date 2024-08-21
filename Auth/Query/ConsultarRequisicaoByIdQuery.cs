using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarRequisicaoByIdQuery : IRequest<RequisicoesModel>
    {
        public Guid Id { get; set; }
        public ConsultarRequisicaoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
