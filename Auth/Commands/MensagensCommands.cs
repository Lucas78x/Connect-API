using Connect.Auth.DTO;
using MediatR;
using System;

namespace Connect.Auth.Commands
{
    public class CriarMensagemCommand : IRequest<Guid>
    {
        public Guid RemetenteId { get; set; }
        public Guid DestinatarioId { get; set; }
        public string Conteudo { get; set; }

        public CriarMensagemCommand(Guid remetenteId, Guid destinatarioId, string conteudo)
        {
            RemetenteId = remetenteId;
            DestinatarioId = destinatarioId;
            Conteudo = conteudo;
        }
    }

    public class AtualizarMensagemCommand : IRequest
    {
        public Guid MensagemId { get; set; }
        public string NovoConteudo { get; set; }

        public AtualizarMensagemCommand(Guid mensagemId, string novoConteudo)
        {
            MensagemId = mensagemId;
            NovoConteudo = novoConteudo;
        }
    }

    public class MarcarMensagemComoLidaCommand : IRequest
    {
        public Guid MensagemId { get; set; }

        public MarcarMensagemComoLidaCommand(Guid mensagemId)
        {
            MensagemId = mensagemId;
        }
    }

    public class DeletarMensagemCommand : IRequest
    {
        public Guid MensagemId { get; set; }

        public DeletarMensagemCommand(Guid mensagemId)
        {
            MensagemId = mensagemId;
        }
    }
}
