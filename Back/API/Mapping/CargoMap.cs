using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {

            builder.ConfigureBase();
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired();
        }
    }
}
