using Connect.Auth.DTO;
using Connect.Auth.Models;
using MediatR;

namespace Connect.Auth.Commands
{
    public class AtualizarRequisicaoByIdCommand: IRequest<RequisicoesDTO>
    {
        public RequisicaoModel Requisicao { get; set; }
        public AtualizarRequisicaoByIdCommand(RequisicaoModel requisicao)
        {
           Requisicao = requisicao; 
        }
    }
}
