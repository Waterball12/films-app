using System;

namespace FilmsApp.Api.Dto
{
    public record FilmDto
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public float Rating { get; init; }

        public DateTime Release { get; init; }
    }
}
