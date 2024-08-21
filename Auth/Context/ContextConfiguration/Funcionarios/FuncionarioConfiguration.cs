using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Funcionarios
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<FuncionarioDTO>
    {
        public void Configure(EntityTypeBuilder<FuncionarioDTO> builder)
        {
        
            builder
                .ToTable("Funcionario", "Funcionarios")
                .HasKey(x => x.Id);

        
            builder
                .Property(x => x.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Sobrenome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.CPF)
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder
                .Property(x => x.RG)
                .HasColumnType("varchar")
                .HasMaxLength(12)
                .IsRequired();

            builder
                .Property(x => x.Genero)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.DataNascimento)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.Cargo)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Permissao)
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
