using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            //Para mudar o nome da tabela usa o builder.ConfigureBase
            builder.ConfigureBase("Animal");
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(300)")
                .IsRequired();
            builder.Property(c => c.TipoAnimalId)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.GeneroId)
                .HasColumnType("bigint")
                .IsRequired();
        }
    }
}
