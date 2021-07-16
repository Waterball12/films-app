using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmsApp.Api.Dto
{
    public class SignInDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class UserAuth
    {
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public List<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }

    public class UserClaim
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
