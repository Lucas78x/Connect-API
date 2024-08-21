using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Query
{
    public class BuscarRequisicoesQuery : IRequest<List<RequisicoesModel>>
    {
        public BuscarRequisicoesQuery()
        {
        }
    }
}
