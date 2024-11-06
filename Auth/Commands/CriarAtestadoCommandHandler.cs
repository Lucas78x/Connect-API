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
    public class CriarAtestadoCommandHandler : IRequestHandler<CriarAtestadoCommand, AtestadoDTO>
    {
        private readonly DatabaseContext _context;

        public CriarAtestadoCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<AtestadoDTO> Handle(CriarAtestadoCommand request, CancellationToken cancellationToken)
        {

            var dto = await _context.Atestados
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Atestado.Id);

            if (dto == null)
            {
                _context.Atestados.Add(request.Atestado);
                await _context.SaveChangesAsync(cancellationToken);

                return request.Atestado;
            }
            else
            {
                return null;
            }
        }


    }
}
