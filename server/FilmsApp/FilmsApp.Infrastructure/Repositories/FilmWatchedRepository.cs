using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmsApp.Infrastructure.Repositories
{
    public class FilmWatchedRepository : IFilmWatchedRepository
    {
        private readonly FilmContext _context;

        public FilmWatchedRepository(FilmContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<FilmWatched> GetFilmWatchedById(int id, CancellationToken cancellationToken = default)
        {
            return _context.FilmWatched.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        
        /// <inheritdoc />
        public async Task<IEnumerable<FilmWatched>> GetFilmWatchedByUserId(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.FilmWatched.Where(x => x.UserId == userId)
                .ToListAsync(cancellationToken);
        }

        public async Task<FilmWatched> CreateFilmWatchedAsync(int userId, int filmId, CancellationToken cancellationToken = default)
        {
            var filmWatched = new FilmWatched()
            {
                UserId = userId,
                FilmId = filmId
            };

            var result = await _context.FilmWatched.AddAsync(filmWatched, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return result.Entity;
        }

        public async Task<FilmWatched> RemoveFilmWatchedAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _context.FilmWatched.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            _context.FilmWatched.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
