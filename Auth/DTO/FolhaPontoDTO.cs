namespace Connect.Auth.DTO
{
    public class FolhaPontoDTO
    {
        public long Id { get; set; }
        public DateTime DataAtual { get; set; }
        public DateTime DataCriacao { get; set; }
        public int HorasTrabalhadas { get; set; }
        public string UrlPdf { get; set; }

        public FuncionarioDTO Funcionario { get; set; }
        public Guid OwnerId { get; set; }
    }
}
