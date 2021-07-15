#nullable enable
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Domain.Models
{
    /// <summary>
    /// Repository for dealing with film table
    /// </summary>
    public interface IFilmRepository
    {
        /// <summary>
        /// Fetch a film given an id
        /// </summary>
        /// <param name="id">The if of the film</param>
        /// <param name="cancellationToken"></param>
        /// <returns>If found a <see cref="Film"/> or null in case not</returns>
        Task<Film?> GetFilmByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Fetch all the available films
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A collection fo <see cref="Film"/></returns>
        Task<IEnumerable<Film>> GetFilmsAsync(CancellationToken cancellationToken = default);
    }
}
