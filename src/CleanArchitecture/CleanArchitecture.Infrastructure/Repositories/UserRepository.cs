

using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User, UserId>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User?> GetByEmailAsync(Domain.Users.Email Email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == Email, cancellationToken);   
        }

        public async Task<bool> isUserExists(Domain.Users.Email Email, CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<User>().AnyAsync(x => x.Email == Email, cancellationToken);
        }
    }
}
