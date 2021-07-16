using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="signIn"></param>
        /// <param name="token"></param>
        /// <returns></returns>
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
                new (ClaimTypes.Name, user.Username),
                new("UserId", user.Id.ToString())
            };

            var authUser = TokenUtils.GenerateTokenFor(user, claims);

            return Ok(authUser);
        }

        /// <summary>
        /// Sign out the user
        /// </summary>
        /// <returns></returns>
        [HttpPost("sign-out")]
        [Authorize]
        public async Task<ActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();

            return Ok();
        }
    }
}
