using System;
using FilmsApp.Domain.Models;

namespace FilmsApp.Api.Dto
{
    /// <summary>
    /// Dto for <see cref="Film"/>
    /// </summary>
    public record FilmDto
    {
        /// <inheritdoc cref="Film.Id"/>
        public int Id { get; init; }
        
        /// <inheritdoc cref="Film.Name"/>
        public string Name { get; init; }
        
        /// <inheritdoc cref="Film.Rating"/>
        public float Rating { get; init; }
        
        /// <inheritdoc cref="Film.Release"/>
        public DateTime Release { get; init; }
    }
}
