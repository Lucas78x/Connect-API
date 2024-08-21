

using Connect.Auth.Context.ContextConfiguration.Login;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<LoginDTO> Logins { get; set; }


        internal static void LoginEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}