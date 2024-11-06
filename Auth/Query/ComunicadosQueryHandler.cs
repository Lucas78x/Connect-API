using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Connect.Auth.Query
{
    public class ObterComunicadosQueryHandler : IRequestHandler<ObterComunicadosQuery, List<ComunicadosDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterComunicadosQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<ComunicadosDTO>> Handle(ObterComunicadosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Comunicados
                 .AsNoTracking().ToListAsync(cancellationToken);
        }
    }


}
