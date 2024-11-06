namespace Connect.Auth.DTO
{
    public class FeriasDTO
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Observacoes { get; set; }

        public FuncionarioDTO Funcionario { get; set; }
        public Guid OwnerId { get; set; }
    }
}
