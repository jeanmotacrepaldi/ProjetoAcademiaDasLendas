using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class RacaMap : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            builder.ConfigureBase();
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)").IsRequired();
        }
    }
}
