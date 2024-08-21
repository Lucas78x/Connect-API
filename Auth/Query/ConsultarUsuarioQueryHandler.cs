using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query;
using Connect.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class ConsultarUsuarioQueryHandler : IRequestHandler<ConsultarUsuarioQuery, LoginDTO>
    {
        private readonly DatabaseContext _context;

        public ConsultarUsuarioQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<LoginDTO> Handle(ConsultarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var password = SHA256Encrypt.Encrypt(request.Password);
            var usuario = await _context.Logins
                .Include(u => u.Funcionario)  
                .Where(u => u.Username == request.Username && u.PasswordHash == password)
                .FirstOrDefaultAsync(cancellationToken);


            return usuario;
        }
    }
}
