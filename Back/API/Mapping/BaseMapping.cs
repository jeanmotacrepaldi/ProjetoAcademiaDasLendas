using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Mapping
{
    public static class BaseMapping
    {
        public static void ConfigureBase<T>(this EntityTypeBuilder<T> builder, string table = null)
        where T : Base
        {
            var tipo = typeof(T);

            builder.ToTable(table ?? tipo.Name);

            builder.Property(c => c.Id)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.DataCadastro)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(c => c.DataAtualizado)
                .HasColumnType("datetime");
            builder.Property(c => c.DataInativado)
                .HasColumnType("datetime");
            builder.Property(c => c.DataReativado)
                .HasColumnType("datetime");
            builder.Property(c => c.UsuarioIdCadastro)
                .HasColumnType("bigint")
                .IsRequired();
            builder.Property(c => c.UsuarioIdAtualizado)
                .HasColumnType("bigint");
            builder.Property(c => c.UsuarioIdInativado)
                .HasColumnType("bigint");
            builder.Property(c => c.UsuarioIdReativado)
                .HasColumnType("bigint");
            builder.Property(c => c.Status)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
