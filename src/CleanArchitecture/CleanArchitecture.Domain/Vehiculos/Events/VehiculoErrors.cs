using CleanArchitecture.Domain.Abstractions;


namespace CleanArchitecture.Domain.Vehiculos.Events
{
    public class VehiculoErrors
    {
        public static Error NotFound = new(
                       "Vehiculo.NotFound",
                        "No existe el vehiculo con este id"
                   );
        public static Error Error = new(
                        "Vehiculo.Error",
                       "Error al intentar reservar el vehiculo"
                   );
    }
}
