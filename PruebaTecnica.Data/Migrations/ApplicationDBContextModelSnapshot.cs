﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnica.Data;

#nullable disable

namespace PruebaTecnica.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaTecnica.Entities.Articulo", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.RelacionArticuloTienda", b =>
                {
                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("TiendaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelacionArticuloTiendaId")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId", "TiendaId");

                    b.HasIndex("TiendaId");

                    b.ToTable("RelacionesArticuloTienda");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.RelacionClienteArticulo", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("RelacionClienteArticuloId")
                        .HasColumnType("int");

                    b.HasKey("ClienteId", "ArticuloId");

                    b.HasIndex("ArticuloId");

                    b.ToTable("RelacionesClienteArticulo");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.Tienda", b =>
                {
                    b.Property<int>("TiendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TiendaId"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sucursal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TiendaId");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.RelacionArticuloTienda", b =>
                {
                    b.HasOne("PruebaTecnica.Entities.Articulo", "Articulo")
                        .WithMany("TiendasDondeSeEncuentra")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaTecnica.Entities.Tienda", "Tienda")
                        .WithMany("ArticulosDisponibles")
                        .HasForeignKey("TiendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Tienda");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.RelacionClienteArticulo", b =>
                {
                    b.HasOne("PruebaTecnica.Entities.Articulo", "Articulo")
                        .WithMany("ClientesQueLoCompraron")
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PruebaTecnica.Entities.Cliente", "Cliente")
                        .WithMany("ArticulosComprados")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.Articulo", b =>
                {
                    b.Navigation("ClientesQueLoCompraron");

                    b.Navigation("TiendasDondeSeEncuentra");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.Cliente", b =>
                {
                    b.Navigation("ArticulosComprados");
                });

            modelBuilder.Entity("PruebaTecnica.Entities.Tienda", b =>
                {
                    b.Navigation("ArticulosDisponibles");
                });
#pragma warning restore 612, 618
        }
    }
}
