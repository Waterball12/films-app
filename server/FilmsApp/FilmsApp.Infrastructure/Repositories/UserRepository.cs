
#nullable enable
using FilmsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FilmContext _context;

        public UserRepository(FilmContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Username == username && x.Password == password, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<bool> ValidateUserAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            return await _context.User.AnyAsync(x => x.Username == username && x.Password == password, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<User> CreateUserAsync(string username, string password, CancellationToken cancellationToken = default)
        {
            var result = await _context.User.AddAsync(new User()
            {
                Password = password,
                Username = username
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }
    }
}
