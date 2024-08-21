using Connect.Auth.Context;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Handlers
{
    public class BuscarRequisicoesQueryHandler : IRequestHandler<BuscarRequisicoesQuery, List<RequisicoesModel>>
    {
        private readonly DatabaseContext _context;

        public BuscarRequisicoesQueryHandler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<RequisicoesModel>> Handle(BuscarRequisicoesQuery request, CancellationToken cancellationToken)
        {



            var requisicoes = await _context.Requisitos
                .AsNoTracking()          
                .ToListAsync();



            if (requisicoes != null)
            {
                List<RequisicoesModel> requisicoesModel = new List<RequisicoesModel>();

                foreach (var requisicao in requisicoes)
                {
                    var usuario = await _context.Funcionarios
                         .Where(u => u.Id == requisicao.RequisitanteId)
                         .FirstOrDefaultAsync(cancellationToken);
                    if (usuario != null)
                    {
                        var newRequisicoes = new RequisicoesModel(requisicao.Id, requisicao.Descricao, requisicao.Status, requisicao.FuncionarioId, requisicao.Setor, $"{usuario.Nome} {usuario.Sobrenome}", requisicao.RequisitanteId, requisicao.DataInicio, requisicao.DataFinalizacao, requisicao.DescricaoSolucao);
                        requisicoesModel.Add(newRequisicoes);
                    }
                }

                return requisicoesModel;
            }


            return null;
        }
    }
}
