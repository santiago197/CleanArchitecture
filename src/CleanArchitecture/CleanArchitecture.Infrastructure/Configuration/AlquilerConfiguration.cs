﻿

using CleanArchitecture.Domain.Alquileres;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configuration
{
    internal sealed class AlquilerConfiguration: IEntityTypeConfiguration<Alquiler>
    {
        public void Configure(EntityTypeBuilder<Alquiler> builder)
        {
            builder.ToTable("alquires");
            builder.HasKey(alquiler => alquiler.Id);

            builder.OwnsOne(alquiler => alquiler.PrecioPorPeriodo, precioBuilder =>
            {
                precioBuilder.Property(precio => precio.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            
            builder.OwnsOne(alquiler => alquiler.Mantenimiento, precioBuilder =>
            {
                precioBuilder.Property(precio => precio.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            
            builder.OwnsOne(alquiler => alquiler.Accesorios, precioBuilder =>
            {
                precioBuilder.Property(precio => precio.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });
            
            builder.OwnsOne(alquiler => alquiler.PrecioTotal, precioBuilder =>
            {
                precioBuilder.Property(precio => precio.TipoMoneda)
                    .HasConversion(tipoMoneda => tipoMoneda.Codigo, codigo => TipoMoneda.FromCodigo(codigo!));
            });

            builder.OwnsOne(alquiler => alquiler.Duracion);

            builder.HasOne<Vehiculo>()
                .WithMany()
                .HasForeignKey(Alquiler => Alquiler.VehiculoId);

            builder.HasOne<Domain.Users.User>()
                .WithMany()
                .HasForeignKey(alquiler => alquiler.UserId);
        }
    }
}
