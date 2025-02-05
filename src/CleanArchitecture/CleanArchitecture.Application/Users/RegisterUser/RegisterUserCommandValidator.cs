
using FluentValidation;

namespace CleanArchitecture.Application.Users.RegisterUser
{
    internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.Nombre).NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(c => c.Apellidos).NotEmpty().WithMessage("El apellido es requerido");
            RuleFor(c => c.Email).EmailAddress();
            RuleFor(c => c.Password).MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres");

        }
    }
}
