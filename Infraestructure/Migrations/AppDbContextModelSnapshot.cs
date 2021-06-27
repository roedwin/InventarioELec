﻿// <auto-generated />
using System;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Electrodoméstico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Electrodoméstico");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Sucursal", b =>
                {
                    b.Property<int>("IdSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ElectrodomésticoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSucursal");

                    b.HasIndex("ElectrodomésticoId");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TipoCategoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ElectrodomésticoId")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("ElectrodomésticoId");

                    b.ToTable("TipoCategoria");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Sucursal", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Electrodoméstico", null)
                        .WithMany("Sucursales")
                        .HasForeignKey("ElectrodomésticoId");
                });

            modelBuilder.Entity("ApplicationCore.Entities.TipoCategoria", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Electrodoméstico", null)
                        .WithMany("TipoCategoria")
                        .HasForeignKey("ElectrodomésticoId");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Electrodoméstico", b =>
                {
                    b.Navigation("Sucursales");

                    b.Navigation("TipoCategoria");
                });
#pragma warning restore 612, 618
        }
    }
}
