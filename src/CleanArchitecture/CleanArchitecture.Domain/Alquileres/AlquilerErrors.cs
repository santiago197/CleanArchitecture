
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Alquileres
{
    public static class AlquilerErrors
    {
        public static Error NotFound = new Error(
            "Alquiler.Found", 
            "El alquiler con el Id especificado no fue encontrado"
        );

        public static Error Overlap = new Error(
            "Alquiler.Overlap", 
            "El alquiler está siendo tomado por 2 o más clientes en la misma fecha"
        );
        public static Error NotReserved = new Error(
            "Alquiler.NotReserved",
            "El alquiler no está reservado"
        );
        public static Error NotConfirmed = new Error(
            "Alquiler.NotConfirmed",
            "El alquiler no está confirmado"
        );
        public static Error AlreadyConfirmed = new Error(
            "Alquiler.AlreadyConfirmed",
            "El alquiler ya está confirmado"
        );

    }
}
