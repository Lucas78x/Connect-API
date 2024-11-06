using Connect.Auth.Context;
using Connect.Auth.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Commands
{

    public class CriarComunicadosCommandHandler : IRequestHandler<CriarComunicadosCommand, ComunicadosDTO>
    {
        private readonly DatabaseContext _context;

        public CriarComunicadosCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ComunicadosDTO> Handle(CriarComunicadosCommand request, CancellationToken cancellationToken)
        {
            await _context.Comunicados.AddAsync(request.Comunicado);
            await _context.SaveChangesAsync();
            return request.Comunicado;
        }
    }

    public class DeletarComunicadosCommandHandler : IRequestHandler<DeletarComunicadosCommand>
    {
        private readonly DatabaseContext _context;

        public DeletarComunicadosCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletarComunicadosCommand request, CancellationToken cancellationToken)
        {
            var comunicado = await _context.Comunicados
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (comunicado == null)
            {
                throw new Exception("evento não encontrada");
            }

            _context.Comunicados.Remove(comunicado);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


