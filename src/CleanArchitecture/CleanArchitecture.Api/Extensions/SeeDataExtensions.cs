using Bogus;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehiculos;
using CleanArchitecture.Infrastructure;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedDataAuthentication(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var service = scope.ServiceProvider;
            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {
                var context = service.GetRequiredService<ApplicationDbContext>();
                if (!context.Set<User>().Any())
                {
                    var passwordHash = BCrypt.Net.BCrypt.HashPassword("123456");

                    var user = User.Create(
                        new Nombre("Santiago"),
                        new Apellidos("Rodriguez"),
                        new Email("santiago.rodriguez19@outlook.com"),
                        new PasswordHash(passwordHash)
                        );
                    context.Add(user);


                    passwordHash = BCrypt.Net.BCrypt.HashPassword("123");
                    user = User.Create(
                            new Nombre("Admin"),
                            new Apellidos("Admin"),
                            new Email("admin@admin.com"),
                            new PasswordHash(passwordHash)
                            );

                    context.Add(user);
                    context.SaveChangesAsync().Wait();

                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
                logger.LogError(ex.Message);
            }
        }
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnecionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
            using var connection = sqlConnecionFactory.CreateConnection();

            var faker = new Faker();

            List<object> vehiculos = new();

            for (int i = 0; i < 100; i++)
            {
                vehiculos.Add(new
                {
                    Id = Guid.NewGuid(),
                    Vin = faker.Vehicle.Vin(),
                    Modelo = faker.Vehicle.Model(),
                    Pais = faker.Address.Country(),
                    Departamento = faker.Address.State(),
                    Ciudad = faker.Address.City(),
                    Calle = faker.Address.StreetAddress(),
                    PrecioMonto = faker.Random.Decimal(10000, 200000),
                    PrecioTipoMoneda = "USD",
                    PrecioMantenimiento = faker.Random.Decimal(100, 200),
                    PrecioMantenimientoTipoMoneda = "USD",
                    Accesorios = new List<int> { (int)Accesorio.Wifi, (int)Accesorio.AppleCar },
                    FechaUltima = DateTime.MinValue
                });
            }

            const string sql = """
                INSERT INTO public.vehiculos
                (id, vin, modelo, direccion_pais, direccion_departamento, direccion_ciudad, direccion_calle, precio_monto, precio_tipo_moneda, mantenimiento_monto, mantenimiento_tipo_moneda, accesorios, fecha_ultimo_alquiler)
                values(@Id, @Vin, @Modelo, @Pais, @Departamento, @Ciudad, @Calle, @PrecioMonto, @PrecioTipoMoneda, @PrecioMantenimiento, @PrecioMantenimientoTipoMoneda, @Accesorios, @FechaUltima)
             """;

            connection.Execute(sql, vehiculos);

        }
    }
}