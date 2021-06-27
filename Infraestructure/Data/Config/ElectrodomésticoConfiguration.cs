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
    public class ElectrodomésticoConfiguration : IEntityTypeConfiguration<Electrodoméstico>
    {
        public void Configure(EntityTypeBuilder<Electrodoméstico> builder)
        {
            builder.ToTable("Electrodoméstico");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.IdCategoria)
                    .IsRequired();

            builder.Property(ci => ci.IdSucursal)
                    .IsRequired();

            builder.Property(ci => ci.Estado)
                    .IsRequired();
        }
    }
}
