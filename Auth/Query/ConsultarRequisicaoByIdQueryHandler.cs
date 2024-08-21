using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class ConsultardtoByIdQueryHandler : IRequestHandler<ConsultarRequisicaoByIdQuery, RequisicoesModel>
    {
        private readonly DatabaseContext _context;

        public ConsultardtoByIdQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RequisicoesModel> Handle(ConsultarRequisicaoByIdQuery request, CancellationToken cancellationToken)
        {
            var dto = await _context.Requisitos
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);

            if (dto != null)
            {
                var usuario = await _context.Funcionarios
                     .Where(u => u.Id == dto.RequisitanteId)
                     .FirstOrDefaultAsync(cancellationToken);

                if (usuario != null)
                {
                    var newRequisicoes = new RequisicoesModel(dto.Id, dto.Descricao, dto.Status, dto.FuncionarioId, dto.Setor, $"{usuario.Nome} {usuario.Sobrenome}", dto.RequisitanteId, dto.DataInicio, dto.DataFinalizacao, dto.DescricaoSolucao);

                    return newRequisicoes;
                }
               
            }

            return null;
        }
    }
}
