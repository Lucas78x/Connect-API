using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Query
{
    public class BuscarFuncionariosQuery : IRequest<List<FuncionarioDTO>>
    {
        public BuscarFuncionariosQuery()
        {
        }
    }
}
