﻿using Connect.Auth.Context.ContextConfiguration.Chat;
using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;

namespace Connect.Auth.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<MensagemDTO> Mensagens { get; set; }
      
        internal static void MensagemEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MensagemConfiguration());
        }
    }
}