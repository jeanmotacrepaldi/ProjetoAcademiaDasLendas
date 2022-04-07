using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class TipoAnimalMap : IEntityTypeConfiguration<TipoAnimal>
    {
        public void Configure(EntityTypeBuilder<TipoAnimal> builder)
        {
            builder.ConfigureBase();
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)").IsRequired();
        }

    }
}
