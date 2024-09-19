using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class BuscarFuncionariosQueryHandler : IRequestHandler<BuscarFuncionariosQuery, List<FuncionarioDTO>>
    {
        private readonly DatabaseContext _context;

        public BuscarFuncionariosQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<FuncionarioDTO>> Handle(BuscarFuncionariosQuery request, CancellationToken cancellationToken)
        {
           return await _context.Funcionarios
                .AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
