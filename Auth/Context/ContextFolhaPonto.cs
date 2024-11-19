using Connect.Auth.Context.ContextConfiguration.FolhaPonto;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<FolhaPontoDTO> Folha { get; set; }


        internal static void FolhaPontoEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FolhaPontoConfiguration());
        }
    }
}