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
    public class CriarRelatoBugCommandHandler : IRequestHandler<CriarRelatoBugCommand,  RelatoBugModel>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public CriarRelatoBugCommandHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RelatoBugModel> Handle(CriarRelatoBugCommand request, CancellationToken cancellationToken)
        {

            var dto = await _context.Relatos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Bug.Id);

            if (dto == null)
            {
                var bugDTO = _mapper.Map<RelatoBugDTO>(request.Bug);
                _context.Relatos.Add(bugDTO);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<RelatoBugModel>(bugDTO);
            }
            else
            {
                return null;
            }
        }


    }
}
