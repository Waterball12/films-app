#nullable enable
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Domain.Models
{
    /// <summary>
    /// Repository for dealing with the user table
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get a user given it's details
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The user password</param>
        /// <param name="cancellationToken"></param>
        /// <returns>If found an instance of <see cref="User"/> or null in case not</returns>
        Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validate if the given details are matching the one from the data access
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The user password</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Whether the user details are correct or not</returns>
        Task<bool> ValidateUserAsync(string username, string password, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="password">The user password</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The created <see cref="User"/></returns>
        Task<User> CreateUserAsync(string username, string password, CancellationToken cancellationToken = default);
    }
}