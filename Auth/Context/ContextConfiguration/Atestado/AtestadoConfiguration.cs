using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Atestado
{
    public class AtestadoConfiguration : IEntityTypeConfiguration<AtestadoDTO>
    {
        public void Configure(EntityTypeBuilder<AtestadoDTO> builder)
        {
            builder
                .ToTable("Atestado", "Funcionarios")
                .HasKey(m => m.Id);

      
            builder
                .Property(m => m.Motivo)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(m => m.UrlAnexo)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .HasOne(m => m.Funcionario)
                .WithMany()
                .HasForeignKey(m => m.ownerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}