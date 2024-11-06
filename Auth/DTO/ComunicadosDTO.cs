namespace Connect.Auth.DTO
{
    public class ComunicadosDTO
    {
        public Guid Id { get; set; } 
        public string Titulo { get; set; } 
        public string Mensagem { get; set; } 
        public DateTime DataPublicacao { get; set; }
        public bool Ativo { get; set; } 

        public ComunicadosDTO(Guid id,string titulo,string mensagem, DateTime dataPublicacao, bool ativo = true) 
        { 
            Id = id;
            Titulo = titulo;
            Mensagem = mensagem;
            DataPublicacao = dataPublicacao;
            Ativo = ativo;
        }
    }
    
}
