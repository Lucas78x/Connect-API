using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query;
using Connect.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class AlterarSenhaUsuarioQueryHandler : IRequestHandler<AlterarSenhaUsuarioQuery, ChangePasswordModel>
    {
        private readonly DatabaseContext _context;

        public AlterarSenhaUsuarioQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ChangePasswordModel> Handle(AlterarSenhaUsuarioQuery request, CancellationToken cancellationToken)
        {
            var passwordHash = SHA256Encrypt.Encrypt(request.ChangePassword.CurrentPassword);

            var usuario = await _context.Logins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.ChangePassword.Id && x.PasswordHash == passwordHash);

            if (usuario != null)
            {
               var newPasswordHash = SHA256Encrypt.Encrypt(request.ChangePassword.NewPassword);
                usuario.SetNewPasswordHash(newPasswordHash);
                usuario.SetFirstLogin(false);

                _context.Update(usuario);
                _context.SaveChanges();

                return request.ChangePassword;
            }

            return null;
        }
    }
}
