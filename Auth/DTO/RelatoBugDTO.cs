using Connect.Auth.Enums;

namespace Connect.Auth.DTO
{
    public class RelatoBugDTO
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataCriacao { get; set; }
        public StatusBugEnum Status { get; set; }
    }
}
