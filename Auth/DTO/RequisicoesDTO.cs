using Connect.Auth.Enums;

namespace Connect.Auth.DTO
{
    public class RequisicoesDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoStatusEnum Status { get; set; }
        public Guid FuncionarioId { get; set; }
        public TipoPermissaoEnum Setor { get; set; }
        public Guid RequisitanteId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFinalizacao { get; set; } // Nullable, pois pode não estar definida ainda
        public string DescricaoSolucao { get; set; } // Pode ser null ou vazio se ainda não tiver solução

        public void SetSolucao(string solucao) => DescricaoSolucao = solucao;
        public void SetFinalizacao(DateTime? finalizacao) => DataFinalizacao = finalizacao;
        public void SetStatus(TipoStatusEnum status) => Status = status;
    }
}
