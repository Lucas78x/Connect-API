using Connect.Auth.Enums;

namespace Connect.Auth.Models
{
    public class RelatoBugModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string FrontStatus { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusBugEnum Status { get; set; } // Usando o Enum para o status
    }
}
