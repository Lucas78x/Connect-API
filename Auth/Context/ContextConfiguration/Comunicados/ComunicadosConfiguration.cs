using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Chat
{
    public class ComunicadosConfiguration : IEntityTypeConfiguration<ComunicadosDTO>
    {
        public void Configure(EntityTypeBuilder<ComunicadosDTO> builder)
        {
            builder
                .ToTable("Comunicados", "Comunicados")
                .HasKey(m => m.Id);
                   
            builder
                .Property(m => m.Titulo)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(m => m.Mensagem)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(m => m.DataPublicacao)
                .HasColumnName("DataPublicacao")
                .IsRequired();

            builder
                .Property(m => m.Ativo)
                .HasColumnName("Ativo")
                .HasDefaultValue(false)
                .IsRequired();         
        }
    }
}