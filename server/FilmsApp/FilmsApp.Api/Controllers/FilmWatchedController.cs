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
    [Authorize]
    public class FilmWatchedController : ControllerBase
    {
        private readonly IFilmWatchedRepository _repository;

        public FilmWatchedController(IFilmWatchedRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Fetch all <see cref="FilmWatched"/> for the given user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmWatchedDto>>> GetFilmWatchedAsync(CancellationToken cancellationToken)
        {
            var userId = GetUserId(HttpContext);

            if (userId == null) return Unauthorized();

            var films = await _repository.GetFilmWatchedByUserId(userId.Value, cancellationToken);

            return films.Select(MapToDto).ToList();
        }

        /// <summary>
        /// Create a new <see cref="FilmWatched"/> in the database
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FilmWatchedDto>> CreateFilmWatchedAsync([FromBody] FilmWatchedDto dto, CancellationToken cancellationToken)
        {
            var userId = GetUserId(HttpContext);

            if (userId == null) return Unauthorized();

            var filmWatched = await _repository.CreateFilmWatchedAsync(userId.Value, dto.FilmId, cancellationToken);

            return MapToDto(filmWatched);
        }

        /// <summary>
        /// Delete a <see cref="FilmWatched"/> from the database
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<FilmWatchedDto>> DeleteFilmWatchedAsync([FromBody] FilmWatchedDto dto,
            CancellationToken cancellationToken)
        {
            var filmWatched = await _repository.GetFilmWatchedById(dto.Id, cancellationToken);

            if (filmWatched == null)
                return NotFound();

            var userId = GetUserId(HttpContext);

            if (userId == null) return Unauthorized();

            if (userId.Value != filmWatched.UserId)
                return Unauthorized();

            await _repository.RemoveFilmWatchedAsync(filmWatched.Id, cancellationToken);

            return MapToDto(filmWatched);
        }

        private int? GetUserId(HttpContext httpContext)
        {
            var user = httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId");

            return user != null ? int.Parse(user.Value) : null;
        }

        private FilmWatchedDto MapToDto(FilmWatched filmWatched)
        {
            return new()
            {
                Id = filmWatched.Id,
                UserId = filmWatched.UserId,
                FilmId = filmWatched.FilmId
            };
        }
    }
}
