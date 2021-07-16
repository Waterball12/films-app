using FilmsApp.Domain.Models;

namespace FilmsApp.Api.Dto
{
    /// <summary>
    /// Dto for <see cref="FilmWatched"/>
    /// </summary>
    public record FilmWatchedDto
    {
        /// <inheritdoc cref="FilmWatched.Id"/>
        public int Id { get; init; }

        /// <inheritdoc cref="FilmWatched.FilmId"/>
        public int FilmId { get; init; }

        /// <inheritdoc cref="FilmWatched.UserId"/>
        public int UserId { get; init; }
    }
}
