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
    public class SucursalConfiguration : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.ToTable("Sucursal");

            builder.HasKey(ci => ci.IdSucursal);

            builder.Property(ci => ci.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(ci => ci.Estado)
                    .IsRequired();
        }
    }
}
