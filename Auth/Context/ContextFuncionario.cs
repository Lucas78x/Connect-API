using Connect.Auth.Context.ContextConfiguration.Funcionarios;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<FuncionarioDTO> Funcionarios { get; set; }
        public DbSet<RequisicoesDTO> Requisitos { get; set; }

        internal static void FuncionarioEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FuncionarioConfiguration());
            builder.ApplyConfiguration(new RequisicoesConfiguration());
        }
    }
}