using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Query
{
    public class ConsultarRequisicoesByIdQuery : IRequest<List<RequisicoesModel>>
    {
        public FuncionarioDTO Funcionario { get; set; }
        public ConsultarRequisicoesByIdQuery(FuncionarioDTO funcionario)
        {
            Funcionario = funcionario;
        }
    }
}
