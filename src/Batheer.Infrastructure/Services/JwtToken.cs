using Batheer.Application.Common.Interfaces;
using Batheer.Application.Modules.UserAccess.Authenticate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Services
{
    public class JwtToken : IJwtToken
    {
        private IConfiguration _configuration { get; }
        private readonly ILogger _logger;

        public JwtToken(IConfiguration configuration, ILogger<JwtToken> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string Generate(string username)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtToken:Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", username) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }


        public string Generate(AuthenticateResponse response)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtToken:Secret"));

            var claimItems = new List<Claim>() 
            {
                new Claim(ClaimTypes.Name, response.Username),
                new Claim(ClaimTypes.Role, response.Role),
                new Claim("User_Photo_ObjectKey", response.User_Photo_ObjectKey.ToString()),
                new Claim("CouncilId", response.CouncilId),
                new Claim("CouncilName", response.CouncilName)
            };


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimItems),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
