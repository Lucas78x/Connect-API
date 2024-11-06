using Connect.Auth.Context;
using Connect.Auth.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Commands
{

    public class CriarEventoCommandHandler : IRequestHandler<CriarEventoCommand, EventoDTO>
    {
        private readonly DatabaseContext _context;

        public CriarEventoCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<EventoDTO> Handle(CriarEventoCommand request, CancellationToken cancellationToken)
        {
            await _context.Eventos.AddAsync(request.Evento);
            await _context.SaveChangesAsync();
            return request.Evento;
        }
    }

    public class DeletarEventoCommandHandler : IRequestHandler<DeletarEventoCommand>
    {
        private readonly DatabaseContext _context;

        public DeletarEventoCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarEventoCommand request, CancellationToken cancellationToken)
        {
            var evento = await _context.Eventos
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (evento == null)
            {
                throw new Exception("evento não encontrada");
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


