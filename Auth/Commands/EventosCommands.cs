using Connect.Auth.DTO;
using Connect.Auth.Enums;
using MediatR;
using System;

namespace Connect.Auth.Commands
{
    public class CriarEventoCommand : IRequest<EventoDTO>
    {
       public EventoDTO Evento { get; set; }

        public CriarEventoCommand(EventoDTO evento)
        {
            Evento = evento;
        }
    }
    public class DeletarEventoCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletarEventoCommand(Guid id)
        {
            Id = id;
        }
    }
}
