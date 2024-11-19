using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Login
{
    public class RelatoBugConfiguration : IEntityTypeConfiguration<RelatoBugDTO>
    {
        public void Configure(EntityTypeBuilder<RelatoBugDTO> builder)
        {

            builder
                .ToTable("Relatos", "Bugs")
                .HasKey(x => x.Id);

            builder
           .Property(m => m.Id)
           .ValueGeneratedOnAdd();

            builder
                .Property(x => x.Funcionario)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(x => x.Titulo)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
               .Property(x => x.Descricao)
               .HasColumnType("varchar(max)")
               .IsRequired();

            builder
            .Property(m => m.Data)
            .HasColumnName("Data")
            .IsRequired();

            builder
            .Property(m => m.DataCriacao)
            .HasColumnName("DataCriacao")
            .IsRequired();

        }
    }
}
