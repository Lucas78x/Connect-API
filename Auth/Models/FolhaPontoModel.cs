namespace Connect.Auth.Models
{
    public class FolhaPontoModel
    {
        public long Id { get; set; }
        public string NomeColaborador { get; set; }
        public string Email { get; set; }
        public DateTime DataAtual { get; set; }
        public int HorasTrabalhadas { get; set; }
        public string UrlPdf { get; set; }

        public Guid OwnerId { get; set; }

        public void SetNome(string nome) => NomeColaborador = nome;
    }
}
