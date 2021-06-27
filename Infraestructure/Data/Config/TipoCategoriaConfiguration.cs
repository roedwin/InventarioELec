using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Config
{
    public class TipoCategoriaConfiguration : IEntityTypeConfiguration<TipoCategoria>
    {
        public void Configure(EntityTypeBuilder<TipoCategoria> builder)
        {
            builder.ToTable("TipoCategoria");

            builder.HasKey(ci => ci.IdCategoria);

            builder.Property(ci => ci.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Estado)
                    .IsRequired();
        }
    }
}
