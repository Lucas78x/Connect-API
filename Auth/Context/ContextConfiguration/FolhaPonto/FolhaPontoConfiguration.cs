using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.FolhaPonto
{
    public class FolhaPontoConfiguration : IEntityTypeConfiguration<FolhaPontoDTO>
    {
        public void Configure(EntityTypeBuilder<FolhaPontoDTO> builder)
        {
            builder
                .ToTable("Folha", "Funcionarios")
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.HorasTrabalhadas)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
               .Property(m => m.UrlPdf)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder
            .Property(m => m.DataCriacao)
            .HasColumnName("DataCriacao")
            .IsRequired();

            builder
             .Property(m => m.DataAtual)
             .HasColumnName("DataAtual")
             .IsRequired();
   
            builder
                .HasOne(m => m.Funcionario)
                .WithMany()
                .HasForeignKey(m => m.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}