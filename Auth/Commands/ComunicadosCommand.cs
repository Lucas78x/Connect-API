using Connect.Auth.DTO;
using Connect.Auth.Enums;
using MediatR;
using System;

namespace Connect.Auth.Commands
{
    public class CriarComunicadosCommand : IRequest<ComunicadosDTO>
    {
        public ComunicadosDTO Comunicado { get; set; }

        public CriarComunicadosCommand(ComunicadosDTO comunicado)
        {
            Comunicado = comunicado;
        }
    }
    public class DeletarComunicadosCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeletarComunicadosCommand(Guid id)
        {
            Id = id;
        }
    }
}
