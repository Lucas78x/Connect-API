using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query;
using Connect.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class ConsultarUsuarioByIdQueryHandler : IRequestHandler<ConsultarUsuarioByIdQuery, FuncionarioDTO>
    {
        private readonly DatabaseContext _context;

        public ConsultarUsuarioByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<FuncionarioDTO> Handle(ConsultarUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            
            var usuario = await _context.Logins
                .Include(u => u.Funcionario)
                .Where(u => u.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (usuario?.Funcionario != null)
            {
                usuario.Funcionario.MaskCPF();
                usuario.Funcionario.MaskRG();
            }

            return usuario.Funcionario;
        }
    }
}
