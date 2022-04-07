using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Mapping
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ConfigureBase();
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired();
        }
    }    
}