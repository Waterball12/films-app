using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Api.Controllers;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace FilmsApp.UnitTests
{
    public class FilmWatchedControllerTests
    {
        private readonly Mock<IFilmWatchedRepository> _repository;

        public FilmWatchedControllerTests()
        {
            _repository = new Mock<IFilmWatchedRepository>();
        }

        [Fact]
        public async Task GetFilmWatched_WithLoggedUser_ReturnsFilmWatched()
        {
            var userId = 1;

            var films = new List<FilmWatched>()
            {
                new FilmWatched() {Id = 1},
                new FilmWatched() {Id = 2}
            };

            _repository.Setup(x => x.GetFilmWatchedByUserId(It.IsAny<int>(), CancellationToken.None))
                .ReturnsAsync(films);

            var controller = new FilmWatchedController(_repository.Object);

            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var claims = new ClaimsPrincipal(){};
            claims.AddIdentity(new ClaimsIdentity(new List<Claim>(){new Claim("UserId", userId.ToString())}));
            controller.ControllerContext.HttpContext.User = claims;
            var result = await controller.GetFilmWatchedAsync(CancellationToken.None);

            Assert.NotNull(result);
        }
    }
}
