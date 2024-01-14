using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Batheer.Application.Modules.UserAccess.Authenticate
{
    public class AuthenticateRequest : IRequest<AuthenticateResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
