

using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Users.Events
{
    public static class UserErrors
    {
        public static Error NotFound = new(
            "User.Found",
            "No existe el usuario con este id"
        );
        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
             "Credenciales inválidas"
        );
        public static Error AlreadyExists = new(
            "User.AlreadyExists",
            "El usuario ya existe"
            );
    }
}
