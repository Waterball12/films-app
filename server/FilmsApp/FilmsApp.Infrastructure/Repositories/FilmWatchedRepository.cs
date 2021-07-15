using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Domain.Models;

namespace FilmsApp.Infrastructure.Repositories
{
    public class FilmWatchedRepository : IFilmWatchedRepository
    {
        /// <inheritdoc />
        public Task<FilmWatched> GetFilmWatchedById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        
        /// <inheritdoc />
        public Task<IEnumerable<FilmWatched>> GetFilmWatchedByUserId(int userId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FilmWatched> CreateFilmWatchedAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FilmWatched> RemoveFilmWatchedAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
