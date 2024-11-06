using System.Security.Cryptography;
using System.Text;
using Azure.Core;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Connect.Utils;
using Connect.Auth.Models;
using AutoMapper;

namespace Connect.Auth.Commands
{
    public class CriarFeriasCommandHandler : IRequestHandler<CriarFeriasCommand, int?>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public CriarFeriasCommandHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int?> Handle(CriarFeriasCommand request, CancellationToken cancellationToken)
        {
            var dto = await _context.Ferias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Ferias.Id);

            if (dto == null)
            {
                var feriasDTO = _mapper.Map<FeriasDTO>(request.Ferias);
                _context.Ferias.Add(feriasDTO);
                await _context.SaveChangesAsync(cancellationToken);

                return feriasDTO.Id;
            }
            else
            {
                return null;
            }
        }



    }
}
