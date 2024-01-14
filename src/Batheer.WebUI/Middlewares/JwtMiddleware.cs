using Batheer.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.WebUI.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _configuration { get; }

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IIdentityService identityService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, identityService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IIdentityService identityService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtToken:Secret"));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var username = jwtToken.Claims.First(x => x.Type == "username").Value;
                //var role = jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                //var user_Photo_ObjectKey = jwtToken.Claims.First(x => x.Type == "User_Photo_ObjectKey").Value;
                //var councilId = jwtToken.Claims.First(x => x.Type == "CouncilId").Value;
                //var councilName = jwtToken.Claims.First(x => x.Type == "CouncilName").Value;


                //var claimItems = new List<Claim>()
                //{
                //    new Claim(ClaimTypes.Name, username),
                //    new Claim(ClaimTypes.Role, role),
                //    new Claim("User_Photo_ObjectKey", user_Photo_ObjectKey),
                //    new Claim("CouncilId", councilId),
                //    new Claim("CouncilName", councilName)
                //};
                
                var claimIdentity = new ClaimsIdentity(jwtToken.Claims, JwtBearerDefaults.AuthenticationScheme);
                var claimPrinciple = new ClaimsPrincipal(claimIdentity);

                // attach user to context on successful jwt validation
                //context.Items["User"] = claimPrinciple;

                //await context.SignInAsync(claimPrinciple);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}