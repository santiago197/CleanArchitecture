﻿// <auto-generated />
using System;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250109002805_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CleanArchitecture.Domain.Alquileres.Alquiler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("FechaCancelacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_cancelacion");

                    b.Property<DateTime?>("FechaCompletado")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_completado");

                    b.Property<DateTime?>("FechaConfirmacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_confirmacion");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_creacion");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_entrega");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VehiculoId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehiculo_id");

                    b.HasKey("Id")
                        .HasName("pk_alquires");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_alquires_user_id");

                    b.HasIndex("VehiculoId")
                        .HasDatabaseName("ix_alquires_vehiculo_id");

                    b.ToTable("alquires", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AlquilerId")
                        .HasColumnType("uuid")
                        .HasColumnName("alquiler_id");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("comentario");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_creacion");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("VehiculoId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehiculo_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("AlquilerId")
                        .HasDatabaseName("ix_reviews_alquiler_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.HasIndex("VehiculoId")
                        .HasDatabaseName("ix_reviews_vehiculo_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Apellidos")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("apellidos");

                    b.Property<string>("Email")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehiculos.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_marca");

                    b.ToTable("marca", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehiculos.Vehiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int[]>("Accesorios")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("accesorios");

                    b.Property<DateTime?>("FechaUltimoAlquiler")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("fecha_ultimo_alquiler");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("integer")
                        .HasColumnName("marca_id");

                    b.Property<string>("Modelo")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("modelo");

                    b.Property<string>("Vin")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("vin");

                    b.HasKey("Id")
                        .HasName("pk_vehiculos");

                    b.HasIndex("MarcaId")
                        .HasDatabaseName("ix_vehiculos_marca_id");

                    b.ToTable("vehiculos", (string)null);
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Alquileres.Alquiler", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_alquires_user_user_id");

                    b.HasOne("CleanArchitecture.Domain.Vehiculos.Vehiculo", null)
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_alquires_vehiculo_vehiculo_id");

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Accesorios", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("accesorios_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("accesorios_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquires");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquires_alquires_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Mantenimiento", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("mantenimiento_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("mantenimiento_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquires");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquires_alquires_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "PrecioPorPeriodo", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_por_periodo_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_por_periodo_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquires");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquires_alquires_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "PrecioTotal", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_total_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_total_tipo_moneda");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquires");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquires_alquires_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Alquileres.DateRange", "Duracion", b1 =>
                        {
                            b1.Property<Guid>("AlquilerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateOnly>("Fin")
                                .HasColumnType("date")
                                .HasColumnName("duracion_fin");

                            b1.Property<DateOnly>("Inicio")
                                .HasColumnType("date")
                                .HasColumnName("duracion_inicio");

                            b1.HasKey("AlquilerId");

                            b1.ToTable("alquires");

                            b1.WithOwner()
                                .HasForeignKey("AlquilerId")
                                .HasConstraintName("fk_alquires_alquires_id");
                        });

                    b.Navigation("Accesorios");

                    b.Navigation("Duracion")
                        .IsRequired();

                    b.Navigation("Mantenimiento");

                    b.Navigation("PrecioPorPeriodo");

                    b.Navigation("PrecioTotal");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Reviews.Review", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Alquileres.Alquiler", null)
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_alquires_alquiler_id");

                    b.HasOne("CleanArchitecture.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_user_user_id");

                    b.HasOne("CleanArchitecture.Domain.Vehiculos.Vehiculo", null)
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_vehiculo_vehiculo_id");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Vehiculos.Vehiculo", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Vehiculos.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .HasConstraintName("fk_vehiculos_marca_marca_id");

                    b.OwnsOne("CleanArchitecture.Domain.Vehiculos.Direccion", "Direccion", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("Calle")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_calle");

                            b1.Property<string>("Ciudad")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_ciudad");

                            b1.Property<string>("Departamento")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_departamento");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("direccion_pais");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Mantenimiento", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("mantenimiento_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("mantenimiento_tipo_moneda");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.OwnsOne("CleanArchitecture.Domain.Shared.Moneda", "Precio", b1 =>
                        {
                            b1.Property<Guid>("VehiculoId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Monto")
                                .HasColumnType("numeric")
                                .HasColumnName("precio_monto");

                            b1.Property<string>("TipoMoneda")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("precio_tipo_moneda");

                            b1.HasKey("VehiculoId");

                            b1.ToTable("vehiculos");

                            b1.WithOwner()
                                .HasForeignKey("VehiculoId")
                                .HasConstraintName("fk_vehiculos_vehiculos_id");
                        });

                    b.Navigation("Direccion");

                    b.Navigation("Mantenimiento");

                    b.Navigation("Marca");

                    b.Navigation("Precio");
                });
#pragma warning restore 612, 618
        }
    }
}
