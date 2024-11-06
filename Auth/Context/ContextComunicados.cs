using Connect.Auth.Context.ContextConfiguration.Chat;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<ComunicadosDTO> Comunicados { get; set; }

        internal static void ComunicadosEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ComunicadosConfiguration());
        }
    }
}