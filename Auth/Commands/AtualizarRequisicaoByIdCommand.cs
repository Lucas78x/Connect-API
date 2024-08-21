using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Commands
{
    public class AtualizarRequisicaoByIdCommand: IRequest<RequisicaoModel>
    {
        public RequisicaoModel Requisicao { get; set; }
        public AtualizarRequisicaoByIdCommand(RequisicaoModel requisicao)
        {
           Requisicao = requisicao; 
        }
    }
}
