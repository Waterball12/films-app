using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Api.Controllers;
using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FilmsApp.UnitTests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserRepository> _user;

        public UserControllerTests()
        {
            _user = new Mock<IUserRepository>();
        }


        [Fact]
        public async Task SignInUser_WithValidCredentials_ReturnsAuthToken()
        {
            var user = new SignInDto() {Password = "pass", Username = "user"};


            _user.Setup(x => x.ValidateUserAsync(It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(true);
            _user.Setup(x => x.GetUserAsync(It.IsAny<string>(), It.IsAny<string>(), CancellationToken.None))
                .ReturnsAsync(new User(){Id = It.IsAny<int>(), Password = user.Password, Username = user.Password});


            var controller = new UserController(_user.Object);

            var result = await controller.SignInAsync(user, CancellationToken.None);

            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
