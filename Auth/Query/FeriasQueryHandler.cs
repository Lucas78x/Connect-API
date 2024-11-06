using AutoMapper;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Connect.Auth.Query
{
    public class ObterFeriasQueryHandler : IRequestHandler<ObterFeriasQuery, List<FeriasModel>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ObterFeriasQueryHandler(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FeriasModel>> Handle(ObterFeriasQuery request, CancellationToken cancellationToken)
        {
            var dto = await _context.Ferias
                                         .AsNoTracking()
                                         .Include(f => f.Funcionario)
                                         .ToListAsync(cancellationToken);
            if(dto.Any())
            {
                return _mapper.Map<List<FeriasModel>>(dto);
            }

            return null;
        }
    }


}
