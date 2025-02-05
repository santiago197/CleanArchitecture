

using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Users.Events;


namespace CleanArchitecture.Application.Users.RegisterUser
{
    internal class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var userExits = await _userRepository.isUserExists(email);
            if (userExits)
            {
                return Result.Failure<Guid>(UserErrors.AlreadyExists);
            }
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = User.Create(new Nombre(request.Nombre),
                                       new Apellidos(request.Apellidos),
                                       new Email(request.Email),
                                       new PasswordHash(passwordHash));

            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();

            return user.Id!.Value;
        }
    }
}
