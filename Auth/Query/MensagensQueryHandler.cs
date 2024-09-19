using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Connect.Auth.Query
{
    public class ObterMensagemPorIdQueryHandler : IRequestHandler<ObterMensagemPorIdQuery, MensagemDTO>
    {
        private readonly DatabaseContext _context;

        public ObterMensagemPorIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<MensagemDTO> Handle(ObterMensagemPorIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Mensagens
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == request.MensagemId);
        }
    }

    public class ObterMensagensPorRemetenteQueryHandler : IRequestHandler<ObterMensagensPorRemetenteQuery, List<MensagemDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterMensagensPorRemetenteQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MensagemDTO>> Handle(ObterMensagensPorRemetenteQuery request, CancellationToken cancellationToken)
        {
            return await _context.Mensagens
                 .AsNoTracking()
                 .Include(x => x.Remetente)
                 .Where(x => x.RemetenteId == request.RemetenteId).ToListAsync();
        }
    }

    public class ObterMensagensPorDestinatarioQueryHandler : IRequestHandler<ObterMensagensPorDestinatarioQuery, List<MensagemDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterMensagensPorDestinatarioQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MensagemDTO>> Handle(ObterMensagensPorDestinatarioQuery request, CancellationToken cancellationToken)
        {
            return await _context.Mensagens
                 .AsNoTracking()
                 .Include(x => x.Destinatario)
                 .Where(x => x.DestinatarioId == request.DestinatarioId).ToListAsync();
        }
    }

    public class ObterMensagensNaoLidasPorDestinatarioQueryHandler : IRequestHandler<ObterMensagensNaoLidasPorDestinatarioQuery, List<MensagemDTO>>
    {
        private readonly DatabaseContext _context;


        public ObterMensagensNaoLidasPorDestinatarioQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MensagemDTO>> Handle(ObterMensagensNaoLidasPorDestinatarioQuery request, CancellationToken cancellationToken)
        {
            return await _context.Mensagens
                 .AsNoTracking()
                 .Include(x => x.Destinatario)
                 .Where(x => !x.Lida).ToListAsync(cancellationToken);
        }
    }


    public class ObterTodasMensagensQueryHandler : IRequestHandler<ObterTodasMensagensQuery, List<MensagemDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterTodasMensagensQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<MensagemDTO>> Handle(ObterTodasMensagensQuery request, CancellationToken cancellationToken)
        {
          var dto =  await _context.Mensagens.AsNoTracking()
                          .Include(x => x.Remetente)
                          .Include(x => x.Destinatario) // Incluindo o destinatário
                          .ToListAsync(cancellationToken);

            if(dto != null)
            {
                return dto.OrderBy(x => x.DataEnvio).ToList();
            }

            return new List<MensagemDTO>();
        }
    }
}
