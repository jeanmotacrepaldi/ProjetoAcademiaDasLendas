using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.ConfigureBase();
            builder.Property(c => c.Avatar)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.ConfigureBase();
            builder.Property(c => c.Username)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.ConfigureBase();
            builder.Property(c => c.Email)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.ConfigureBase();
            builder.Property(c => c.Discriminator)
                .HasColumnType("int")
                .IsRequired();
            builder.ConfigureBase();
            builder.Property(c => c.DiscordId)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.ConfigureBase();
            builder.Property(c => c.PerfilAcesso)
                .HasColumnType("varchar(3)")
                .IsRequired();
        }
    }
}
