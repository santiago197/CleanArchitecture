

namespace CleanArchitecture.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
        void Add(User user);
        Task<User?> GetByEmailAsync(Email Email, CancellationToken cancellationToken = default);
        Task<bool> isUserExists (Email Email, CancellationToken cancellationToken = default);
    }
}
