using Connect.Auth.Context.ContextConfiguration.Atestado;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<AtestadoDTO> Atestados { get; set; }


        internal static void AtestadoEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AtestadoConfiguration());
        }
    }
}