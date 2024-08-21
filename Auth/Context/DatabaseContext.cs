using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LoginEntityConfiguration(modelBuilder);
            FuncionarioEntityConfiguration(modelBuilder);
        }
    }
}
