using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilmAsync(CancellationToken cancellationToken)
        {
            var films = await _repository.GetFilmsAsync(cancellationToken);

            return films.Select(x => new FilmDto()
            {
                Id = x.Id, Name = x.Name, Rating = x.Rating,
                Release = x.Release
            }).ToList();
        }

    }
}
