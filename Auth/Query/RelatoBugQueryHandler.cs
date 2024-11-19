using AutoMapper;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Query
{
    public class ObterRelatoBugQueryHandler : IRequestHandler<ObterRelatoBugQuery, List<RelatoBugModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ObterRelatoBugQueryHandler(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RelatoBugModel>> Handle(ObterRelatoBugQuery request, CancellationToken cancellationToken)
        {

            var dto = await _context.Relatos
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

            if (dto != null)
            {
                return _mapper.Map<List<RelatoBugModel>>(dto);
            }


            return new List<RelatoBugModel>();

        }
    }
}
