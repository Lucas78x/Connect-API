namespace Connect.Auth.DTO
{
    public class AtestadoDTO

    {
        /// <summary>
        /// Identificador Unico.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DateTime do Atestado.
        /// </summary>
        public DateTime DataAtestado { get; set; }

        /// <summary>
        /// Motivo do Atestado.
        /// </summary>
        public string Motivo { get; set; }

        /// <summary>
        /// Url de caminho do Atestado.
        /// </summary>
        public string UrlAnexo { get; set; }

        // Reference To Owner
        public FuncionarioDTO Funcionario { get; set; }
        public Guid ownerId { get; set; }

        public AtestadoDTO() { }

        public AtestadoDTO(Guid id, DateTime dataAtestado, string motivo, string urlAnexo, Guid OwnerId)
        {
            Id = id;
            DataAtestado = dataAtestado;
            Motivo = motivo;
            UrlAnexo = urlAnexo;
            ownerId = OwnerId;
        }

    }
}
