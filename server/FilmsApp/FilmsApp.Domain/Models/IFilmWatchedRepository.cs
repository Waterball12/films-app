#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Domain.Models
{
    /// <summary>
    /// Repository for dealing with the film watched table
    /// </summary>
    public interface IFilmWatchedRepository
    {
        /// <summary>
        /// Get a film watched entity given an id
        /// </summary>
        /// <param name="id">Id of the film watched</param>
        /// <param name="cancellationToken"></param>
        /// <returns>An instance of <see cref="FilmWatched"/> or null in case not found</returns>
        Task<FilmWatched?> GetFilmWatchedById(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all the film watched by the user
        /// </summary>
        /// <param name="userId">Id of the film watched</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A collection of <see cref="FilmWatched"/></returns>
        Task<IEnumerable<FilmWatched>> GetFilmWatchedByUserId(int userId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Create a film watched record
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="filmId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The created <see cref="FilmWatched"/></returns>
        Task<FilmWatched> CreateFilmWatchedAsync(int userId, int filmId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove a film watched record
        /// </summary>
        /// <param name="id">Id of the film watched</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The deleted <see cref="FilmWatched"/></returns>
        Task<FilmWatched> RemoveFilmWatchedAsync(int id, CancellationToken cancellationToken = default);
    }
}
