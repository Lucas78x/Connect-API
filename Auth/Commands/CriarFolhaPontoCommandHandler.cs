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
    public class CriarFolhaPontoCommandHandler : IRequestHandler<CriarFolhaPontoCommand, long?>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public CriarFolhaPontoCommandHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long?> Handle(CriarFolhaPontoCommand request, CancellationToken cancellationToken)
        {

            var dto = await _context.Folha
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Folha.Id);

            if (dto == null)
            {
                var folhaDTO = _mapper.Map<FolhaPontoDTO>(request.Folha);
                _context.Folha.Add(folhaDTO);
                await _context.SaveChangesAsync(cancellationToken);

                return folhaDTO.Id;
            }
            else
            {
                return null;
            }
        }


    }
}
