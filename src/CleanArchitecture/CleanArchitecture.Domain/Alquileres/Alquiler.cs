using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Alquileres.Events;
using CleanArchitecture.Domain.Vehiculos;


namespace CleanArchitecture.Domain.Alquileres
{
    public sealed class Alquiler : Entity
    {
        public Alquiler(
            Guid id,
            Guid vehiculoID,
            Guid userId,
            DateRange duracion,
            Moneda precioPorPeriodo,
            Moneda mantenimiento,
            Moneda accesorios,
            Moneda precioTotal,
            AlquilerStatus status,
            DateTime fechaCreacion
            ) : base(id)
        {
            VehiculoId = vehiculoID;
            UserId = userId;
            Duracion = duracion;
            PrecioPorPeriodo = precioPorPeriodo;
            Accesorios = accesorios;
            PrecioTotal = precioTotal;
            Status = status;
            FechaCreacion = fechaCreacion;
        }
        public Guid VehiculoId { get; private set; }
        public Guid UserId { get; private set; }
        public Moneda? PrecioPorPeriodo { get; private set; }
        public Moneda? Mantenimiento { get; private set; }
        public Moneda? Accesorios { get; private set; }
        public Moneda? PrecioTotal { get; private set; }
        public AlquilerStatus Status { get; private set; }
        public DateRange Duracion { get; private set; }
        public DateTime? FechaCreacion { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaCancelacion { get; private set; }
        public DateTime? FechaCompletado { get; private set; }
        public DateTime? FechaEntrega { get; private set; }

        public static Alquiler Reservar(
            Vehiculo vehiculo,
            Guid userId,
            DateRange duracion,
            DateTime fechaCreacion,
            PrecioService precioService
        )
        {
            var precioDetalle = precioService.CalcularPrecio(
                vehiculo,
                duracion
            );
            var alquiler = new Alquiler(
                Guid.NewGuid(),
                vehiculo.Id,
                userId,
                duracion,
                precioDetalle.PrecioPorPeriodo,
                precioDetalle.Mantenimiento,
                precioDetalle.Accesorios,
                precioDetalle.PrecioTotal,
                AlquilerStatus.Reservado,
                fechaCreacion
                );

            alquiler.RaiseDomainEvent(new AlquilerReservadoDomainEvent(alquiler.Id));
            vehiculo.FechaUltimoAlquiler = fechaCreacion;
            return alquiler;
        }

        public Result Confirmar(DateTime fechaConfirmacion)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }
            Status = AlquilerStatus.Confirmado;
            FechaConfirmacion = fechaConfirmacion;

            RaiseDomainEvent(new AlquilerConfirmadoDomainEvent(Id));
            return Result.Success();

        }
        public Result Rechazar(DateTime fechaCancelacion)
        {
            if (Status != AlquilerStatus.Reservado)
            {
                return Result.Failure(AlquilerErrors.NotReserved);
            }
            Status = AlquilerStatus.Rechazado;
            FechaCancelacion = fechaCancelacion;

            RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id));
            return Result.Success();
        }
        public Result Cancelar(DateTime fechaCancelacion)
        {
            if (Status != AlquilerStatus.Confirmado)
            {
                return Result.Failure(AlquilerErrors.NotConfirmed);
            }
            var currentDate = DateOnly.FromDateTime(fechaCancelacion);
            if(currentDate > Duracion.Inicio)
            {
                return Result.Failure(AlquilerErrors.AlreadyConfirmed);
            }
            Status = AlquilerStatus.Cancelado;
            FechaCancelacion = fechaCancelacion;

            RaiseDomainEvent(new AlquilerRechazadoDomainEvent(Id));
            return Result.Success();
        }
    }
}
