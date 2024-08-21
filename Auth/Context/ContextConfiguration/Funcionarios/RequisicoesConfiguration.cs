using Connect.Auth.DTO;
using Connect.Auth.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Funcionarios
{
    public class RequisicoesConfiguration : IEntityTypeConfiguration<RequisicoesDTO>
    {
        public void Configure(EntityTypeBuilder<RequisicoesDTO> builder)
        {
            builder
                .ToTable("Requisicoes", "Funcionarios")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Descricao)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(x => x.Status)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.FuncionarioId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder
                .Property(x => x.Setor)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.RequisitanteId)
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder
                .Property(x => x.DataInicio)
                .HasColumnType("datetime");

            builder
                .Property(x => x.DataFinalizacao)
                .HasColumnType("datetime");

            builder
                .Property(x => x.DescricaoSolucao)
                .HasColumnType("varchar(max)")
                .IsRequired();



        }
    }
}
