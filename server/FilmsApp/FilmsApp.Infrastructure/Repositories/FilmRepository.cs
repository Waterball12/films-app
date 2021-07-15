using FilmsApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Infrastructure.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly FilmContext _context;

        public FilmRepository(FilmContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public async Task<Film?> GetFilmByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Film.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Film>> GetFilmsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Film.ToArrayAsync(cancellationToken);
        }
    }
}
