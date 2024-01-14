using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.UserAccess.Authenticate
{
    public class AuthenticateRequestHandler : IRequestHandler<AuthenticateRequest, AuthenticateResponse>
    {
        private readonly ILogger<AuthenticateRequest> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IJwtToken _jwtToken;

        public AuthenticateRequestHandler(ILogger<AuthenticateRequest> logger, IApplicationDbContext context
            , IJwtToken jwtToken
            )
        {
            _logger = logger;
            _context = context;
            _jwtToken = jwtToken;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                  .Include(i => i.Photo)
                .Where(w => w.UserName == request.Username && w.Password == request.Password)
                .FirstOrDefaultAsync(); //  _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token

            var result = new AuthenticateResponse()
            {
                Username = user.UserName,
                Role = user.UserRole.ToString(),
                User_Photo_ObjectKey = user.Photo.ObjectKey.ToString(),
            };

            switch (user.UserRole)
            {
                case Domain.AuthenticationUsers.User.UserRoles.AdminRole:
                    result.CouncilId = "0";
                    result.CouncilName = "مجلس الجمعيات الأهلية";
                    break;
                case Domain.AuthenticationUsers.User.UserRoles.CouncilRole:

                    var councilUser = _context.AssociationsAffiliatedWithTheCouncilUsers
                        .Include(i => i.AssociationsAffiliatedWithTheCouncil)
                        .Where(w => w.UserName == user.UserName)
                        .FirstOrDefault();
                    if (councilUser != null)
                    {
                        result.CouncilId = councilUser.AssociationsAffiliatedWithTheCouncilId.ToString();
                        result.CouncilName = councilUser.AssociationsAffiliatedWithTheCouncil.Name;
                    }
                    break;

                default:
                    break;
            }

            var token = _jwtToken.Generate(result);

            result.Token = token;
            return result;
        }
    }
}
