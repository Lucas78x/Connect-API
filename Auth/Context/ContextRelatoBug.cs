using Connect.Auth.Context.ContextConfiguration.Login;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<RelatoBugDTO> Relatos { get; set; }


        internal static void RelatoBugEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RelatoBugConfiguration());
        }
    }
}