﻿

using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configuration
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Nombre)
                .HasMaxLength(200)
                .HasConversion(nombre => nombre!.Value, value => new Nombre(value));
            builder.Property(user => user.Apellidos)
                .HasMaxLength(200)
                .HasConversion(apellido => apellido!.Value, value => new Apellidos(value));
            builder.Property(user => user.Email)
                .HasMaxLength(400)
                .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));
            

        }
    }
}
