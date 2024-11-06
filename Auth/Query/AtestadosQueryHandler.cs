using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Connect.Auth.Query
{
    public class ObterAtestadosQueryHandler : IRequestHandler<ObterAtestadosQuery, List<AtestadoDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterAtestadosQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<AtestadoDTO>> Handle(ObterAtestadosQuery request, CancellationToken cancellationToken)
        {
            return await _context.Atestados
                 .AsNoTracking().Where( x=> x.ownerId == request.OwnerId).ToListAsync(cancellationToken);
        }
    }


}
