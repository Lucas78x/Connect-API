using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Ferias
{
    public class FeriasConfiguration : IEntityTypeConfiguration<FeriasDTO>
    {
        public void Configure(EntityTypeBuilder<FeriasDTO> builder)
        {
            builder
                .ToTable("Ferias", "Funcionarios")
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Observacoes)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
             .Property(m => m.DataInicio)
             .HasColumnName("DataInicio")
             .IsRequired();

            builder
            .Property(m => m.DataFim)
            .HasColumnName("DataFim")
            .IsRequired();
                  
            builder
                .HasOne(m => m.Funcionario)
                .WithMany()
                .HasForeignKey(m => m.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}