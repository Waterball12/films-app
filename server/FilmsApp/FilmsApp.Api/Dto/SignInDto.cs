using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmsApp.Api.Dto
{
    /// <summary>
    /// Dto for signin in the user
    /// </summary>
    public class SignInDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    /// <summary>
    /// Response for the sign in endpoint containing the bearer token
    /// </summary>
    public class UserAuth
    {
        public string UserName { get; set; }
        public string BearerToken { get; set; }
    }
}
