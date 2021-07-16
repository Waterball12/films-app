using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FilmsApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmRepository _repository;

        public FilmController(IFilmRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Endpoint for fetching all films
        /// No authorization required
        /// </summary>
        /// <returns>A collection of <see cref="FilmDto"/></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilmAsync(CancellationToken cancellationToken)
        {
            var films = await _repository.GetFilmsAsync(cancellationToken);

            return films.Select(x => new FilmDto()
            {
                Id = x.Id,
                Name = x.Name,
                Rating = x.Rating,
                Release = x.Release
            }).ToList();
        }

    }
}
