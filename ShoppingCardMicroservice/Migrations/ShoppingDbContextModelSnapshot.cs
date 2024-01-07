﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCardMicroservice.Persistencia;

#nullable disable

namespace ShoppingCardMicroservice.Migrations
{
    [DbContext(typeof(ShoppingDbContext))]
    partial class ShoppingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingCardMicroservice.Modelo.CarritoSession", b =>
                {
                    b.Property<int>("CarritoSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoSessionId"), 1L, 1);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.HasKey("CarritoSessionId");

                    b.ToTable("CarritoSessions");
                });

            modelBuilder.Entity("ShoppingCardMicroservice.Modelo.CarritoSessionDetalle", b =>
                {
                    b.Property<int>("CarritoSessionDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarritoSessionDetalleId"), 1L, 1);

                    b.Property<int>("CarritoSessionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarritoSessionDetalleId");

                    b.HasIndex("CarritoSessionId");

                    b.ToTable("CarritoSessionDetalles");
                });

            modelBuilder.Entity("ShoppingCardMicroservice.Modelo.CarritoSessionDetalle", b =>
                {
                    b.HasOne("ShoppingCardMicroservice.Modelo.CarritoSession", "CarritoSession")
                        .WithMany("ListaDetalle")
                        .HasForeignKey("CarritoSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarritoSession");
                });

            modelBuilder.Entity("ShoppingCardMicroservice.Modelo.CarritoSession", b =>
                {
                    b.Navigation("ListaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
