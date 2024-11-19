using AutoMapper;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Query
{
    public class ObterFolhaPontoQueryHandler : IRequestHandler<ObterFolhaPontoQuery, List<FolhaPontoModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ObterFolhaPontoQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FolhaPontoModel>> Handle(ObterFolhaPontoQuery request, CancellationToken cancellationToken)
        {
            if (request.OwnerId.HasValue)
            {
                var dto = await _context.Folha
                                           .AsNoTracking()
                                           .Where(x => x.OwnerId == request.OwnerId)
                                           .Include(f => f.Funcionario)
                                           .ToListAsync(cancellationToken);
                if (dto.Any())
                {

                    return _mapper.Map<List<FolhaPontoModel>>(dto);

                }
            }
            else
            {
                var dto = await _context.Folha
                        .AsNoTracking()
                        .Include(f => f.Funcionario)
                        .ToListAsync(cancellationToken);

                if (dto != null)
                {
                    return _mapper.Map<List<FolhaPontoModel>>(dto);
                }
            }

            return new List<FolhaPontoModel>();

        }
    }
}
