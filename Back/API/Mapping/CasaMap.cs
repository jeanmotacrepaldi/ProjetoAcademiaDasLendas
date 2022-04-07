using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class CasaMap : IEntityTypeConfiguration<Casa>
    {
        public void Configure(EntityTypeBuilder<Casa> builder)
        {
            builder.ConfigureBase();

            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired();

        }
    }
}
