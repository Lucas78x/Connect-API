using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Query;
using Connect.Utils;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class ConsultarFuncionarioByIdQueryHandler : IRequestHandler<ConsultarFuncionarioByIdQuery, FuncionarioDTO>
    {
        private readonly DatabaseContext _context;

        public ConsultarFuncionarioByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<FuncionarioDTO> Handle(ConsultarFuncionarioByIdQuery request, CancellationToken cancellationToken)
        {

            var dto = await _context.Funcionarios
                .Where(u => u.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (dto != null)
            {
                dto.MaskCPF();
                dto.MaskRG();
            }


            return dto;
        }
    }
}
