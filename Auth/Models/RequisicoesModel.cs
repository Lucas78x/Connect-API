using Connect.Auth.Enums;

namespace Connect.Auth.Models
{
    public class RequisicoesModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoStatusEnum Status { get; set; }
        public Guid FuncionarioId { get; set; }
        public TipoPermissaoEnum Setor { get; set; }
        public string RequisitanteNome { get; set; }
        public Guid RequisitanteId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinalizacao { get; set; } // Nullable, pois pode não estar definida ainda
        public string DescricaoSolucao { get; set; } // Pode ser null ou vazio se ainda não tiver solução
       
        public RequisicoesModel(Guid id, string descricao, TipoStatusEnum status, Guid funcionarioId, TipoPermissaoEnum setor, string requisitanteNome, Guid requisitanteId, DateTime? dataInicio, DateTime? dataFinalizacao, string descricaoSolucao)
        {
            Id = id;
            Descricao = descricao;
            Status = status;
            FuncionarioId = funcionarioId;
            Setor = setor;
            RequisitanteNome = requisitanteNome;
            RequisitanteId = requisitanteId;
            DataInicio = dataInicio;
            DataFinalizacao = dataFinalizacao;
            DescricaoSolucao = descricaoSolucao;
        }
    }
}
