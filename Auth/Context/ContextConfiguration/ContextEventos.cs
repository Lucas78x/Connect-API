using Connect.Auth.Context.ContextConfiguration.Chat;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<EventoDTO> Eventos { get; set; }

        internal static void EventosEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EventosConfiguration());
        }
    }
}