using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Connect.Auth.Query
{
    public class ObterEventoPorSetorQueryHandler : IRequestHandler<ObterEventoPorSetorQuery, List<EventoDTO>>
    {
        private readonly DatabaseContext _context;

        public ObterEventoPorSetorQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<EventoDTO>> Handle(ObterEventoPorSetorQuery request, CancellationToken cancellationToken)
        {
            return await _context.Eventos
                 .AsNoTracking()
                 .Where(x => (int)x.Setor== request.Setor.GetHashCode()).ToListAsync(cancellationToken); 
        }
    }

   
}
