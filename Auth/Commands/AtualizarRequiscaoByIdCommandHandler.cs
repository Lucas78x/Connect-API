using Connect.Auth.Commands;
using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Enums;
using Connect.Auth.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class AtualizarRequisicaoByIdCommandHandler : IRequestHandler<AtualizarRequisicaoByIdCommand, RequisicaoModel>
    {
        private readonly DatabaseContext _context;

        public AtualizarRequisicaoByIdCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<RequisicaoModel> Handle(AtualizarRequisicaoByIdCommand request, CancellationToken cancellationToken)
        {
            var dto = await _context.Requisitos
                .AsNoTracking()
                .Where(x => x.Id == request.Requisicao.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (dto != null)
            {
                dto.SetStatus((TipoStatusEnum)Enum.Parse(typeof(TipoStatusEnum), request.Requisicao.Status));
                dto.SetFinalizacao(request.Requisicao.DataFinalizacao);
                dto.SetSolucao(request.Requisicao.DescricaoSolucao);

                _context.Update(dto);
                _context.SaveChanges();

                return request.Requisicao;
            }

            return null;
        }
    }
}
