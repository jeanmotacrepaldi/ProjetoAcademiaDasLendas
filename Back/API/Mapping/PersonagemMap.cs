using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class PersonagemMap : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            //Para mudar o nome da tabela usa o builder.ConfigureBase
            builder.ConfigureBase("Nome");
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(c => c.Idade)
                .HasColumnType("int")
                .IsRequired();
            builder.Property(c => c.Personalidade)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(c => c.Historia)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(c => c.Aparencia)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(c => c.GeneroId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.RacaId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.CasaId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.AnimalId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.CargoId)
                .HasColumnType("bigint")
                .IsRequired();
        }
    }
}
