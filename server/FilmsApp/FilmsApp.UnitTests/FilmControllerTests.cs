using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Api.Controllers;
using FilmsApp.Domain.Models;
using Moq;
using Xunit;

namespace FilmsApp.UnitTests
{
    public class FilmControllerTests
    {
        private readonly Mock<IFilmRepository> _repository;

        public FilmControllerTests()
        {
            _repository = new Mock<IFilmRepository>();
        }

        [Fact]
        public async Task GetFilm_ReturnsAllFilms()
        {
            var films = new List<Film>()
            {
                new Film() {Id = 1},
                new Film() {Id = 2}
            };

            _repository.Setup(x => x.GetFilmsAsync(CancellationToken.None))
                .ReturnsAsync(films);

            var controller = new FilmController(_repository.Object);

            var result = await controller.GetFilmAsync(CancellationToken.None);


            Assert.NotNull(result);

            Assert.Equal(films.Count, result.Value.Count());

        }
    }
}
