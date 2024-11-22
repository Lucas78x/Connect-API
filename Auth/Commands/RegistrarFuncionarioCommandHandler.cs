using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Connect.Utils;

namespace Connect.Auth.Commands
{
    public class RegistrarFuncionarioCommandHandler : IRequestHandler<RegistrarFuncionarioCommand, LoginDTO>
    {
        private readonly DatabaseContext _context;

        public RegistrarFuncionarioCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<LoginDTO> Handle(RegistrarFuncionarioCommand request, CancellationToken cancellationToken)
        {

            var dto = await _context.Funcionarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CPF == request.Login.Funcionario.CPF
                || x.RG == request.Login.Funcionario.RG);

            if (dto == null)
            {
                _context.Funcionarios.Add(request.Login.Funcionario);
                request.Login.PasswordHash = SHA256Encrypt.Encrypt(request.Login.PasswordHash);
                request.Login.SetFirstLogin();

                _context.Logins.Add(request.Login);
                await _context.SaveChangesAsync(cancellationToken);

                return request.Login;
            }
            else
            {
                return null;
            }
        }

        
    }
}
