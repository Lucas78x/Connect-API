using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class EventosConfiguration : IEntityTypeConfiguration<EventoDTO>
{
    public void Configure(EntityTypeBuilder<EventoDTO> builder)
    {
        builder
            .ToTable("Eventos", "Eventos") // Corrigido para "Eventos"
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Titulo)
            .HasColumnName("Titulo")
            .IsRequired();

        builder
            .Property(m => m.Descricao)
            .HasColumnName("Descricao")
            .IsRequired();

        builder
            .Property(m => m.Data)
            .HasColumnName("Data")
            .IsRequired();

        builder
            .Property(m => m.Local)
            .HasColumnName("Local")
            .IsRequired();

        builder
            .Property(m => m.Link)
            .HasColumnName("Link")
            .IsRequired();

        builder
            .Property(x => x.Setor)
            .HasColumnType("int")
            .IsRequired();
    }
}
