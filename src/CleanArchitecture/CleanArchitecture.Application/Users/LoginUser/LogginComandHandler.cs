
using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Users.Events;

namespace CleanArchitecture.Application.Users.LoginUser
{
    internal sealed class LogginComandHandler : ICommandHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public LogginComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //Verificar que el usuario exista
            var user = await _userRepository.GetByEmailAsync(new Email(request.Email), cancellationToken);
            if (user is null)
            {
                return Result.Failure<string>(UserErrors.NotFound);
            }
            //Verificar que la contraseña sea correcta
            if(BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash!.Value))
            {
                return Result.Failure<string>(UserErrors.InvalidCredentials);
            }   
                
            //Generar token


        }
    }
}
