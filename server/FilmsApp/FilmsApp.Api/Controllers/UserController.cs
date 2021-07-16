using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilmsApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<ActionResult<UserAuth>> SignInAsync([FromBody] SignInDto signIn, CancellationToken token)
        {
            var validate = await _user.ValidateUserAsync(signIn.Username, signIn.Password, token);

            if (!validate)
                return BadRequest();

            var user = await _user.GetUserAsync(signIn.Username, signIn.Password, token);

            if (user == null)
                return StatusCode(500);

            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Username)
            };

            var authUser = TokenUtils.BuildUserAuthObject(user, claims);

            return Ok(authUser);
        }

        [HttpPost("sign-out")]
        [Authorize]
        public async Task<ActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();

            return Ok();
        }
    }
}
