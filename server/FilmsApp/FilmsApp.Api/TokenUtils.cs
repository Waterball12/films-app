using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FilmsApp.Api.Dto;
using FilmsApp.Domain.Models;
using FilmsApp.Infrastructure;
using Microsoft.IdentityModel.Tokens;

namespace FilmsApp.Api
{
    /// <summary>
    /// Utility class to generate JWT tokens
    /// </summary>
    public class TokenUtils
    {
        /// <summary>
        /// Generate a new token for the given <see cref="User"/>
        /// </summary>
        /// <param name="user"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public static UserAuth GenerateTokenFor(User user, List<Claim> claims)
        {
            var appUserAuth = new UserAuth
            {
                BearerToken = GetToken(user, claims),
                UserName = user.Username
            };

            return appUserAuth;
        }

        private static string GetToken(User user, List<Claim> claims)
        {
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenConfigs.Secret));

            var creds = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(TokenConfigs.Issuer, TokenConfigs.Audience, claims, expires: DateTime.UtcNow.AddDays(30), signingCredentials: creds);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenValue;
        }
    }
}
