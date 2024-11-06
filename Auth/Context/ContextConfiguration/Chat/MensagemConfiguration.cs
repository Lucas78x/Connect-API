using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Chat
{
    public class AtestadoConfiguration : IEntityTypeConfiguration<MensagemDTO>
    {
        public void Configure(EntityTypeBuilder<MensagemDTO> builder)
        {
            builder
                .ToTable("Mensagem", "Chat")
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .HasColumnName("MensagemId")
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.RemetenteId)
                .HasColumnName("RemetenteId")
                .IsRequired();

            builder
                .Property(m => m.DestinatarioId)
                .HasColumnName("DestinatarioId")
                .IsRequired();

            builder
                .Property(m => m.Conteudo)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(m => m.DataEnvio)
                .HasColumnName("DataEnvio")
                .IsRequired();

            builder
                .Property(m => m.Lida)
                .HasColumnName("Lida")
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .HasOne(m => m.Remetente)
                .WithMany()
                .HasForeignKey(m => m.RemetenteId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(m => m.Destinatario)
                .WithMany()
                .HasForeignKey(m => m.DestinatarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}