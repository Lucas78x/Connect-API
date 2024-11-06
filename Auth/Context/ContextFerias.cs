

using Connect.Auth.Context.ContextConfiguration.Ferias;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<FeriasDTO> Ferias{ get; set; }


        internal static void FeriasEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FeriasConfiguration());
        }
    }
}