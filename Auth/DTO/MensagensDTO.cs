namespace Connect.Auth.DTO
{
    public class MensagemDTO
    {
        public Guid Id { get; set; }
        public Guid RemetenteId { get; set; }
        public Guid DestinatarioId { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Lida { get; set; }

        public FuncionarioDTO Remetente { get; set; }
        public FuncionarioDTO Destinatario { get; set; } 

        public MensagemDTO() { }

        public MensagemDTO(Guid remetenteId, Guid destinatarioId, string conteudo)
        {
            Id = Guid.NewGuid();
            RemetenteId = remetenteId;
            DestinatarioId = destinatarioId;
            Conteudo = conteudo;
            DataEnvio = DateTime.Now;
            Lida = false;
        }

        public void AtualizarConteudo( string novoConteudo)
        {
            Conteudo = novoConteudo;
        }

        public void MarcarComoLida()
        {
            Lida = true;
        }
    }
}

