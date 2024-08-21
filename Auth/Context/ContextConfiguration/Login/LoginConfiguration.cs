using Connect.Auth.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connect.Auth.Context.ContextConfiguration.Login
{
    public class LoginConfiguration : IEntityTypeConfiguration<LoginDTO>
    {
        public void Configure(EntityTypeBuilder<LoginDTO> builder)
        {

            builder
                .ToTable("Usuario", "Usuarios")
                .HasKey(x => x.Id);


            builder
                .Property(x => x.Username)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();


            builder
                .Property(x => x.PasswordHash)
                .HasColumnType("varchar(max)")
                .IsRequired();


            builder
                .HasOne(l => l.Funcionario)
                .WithMany()  
                .HasForeignKey(l => l.FuncionarioId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
