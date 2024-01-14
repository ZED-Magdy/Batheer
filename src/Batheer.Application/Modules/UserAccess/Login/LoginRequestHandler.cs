using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.UserAccess.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ILogger<LoginRequest> _logger;
        private readonly IHttpContextService _httpContextService;
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;


        public LoginRequestHandler(ILogger<LoginRequest> logger, IHttpContextService httpContextService, IApplicationDbContext context, IDateTime dateTime)
        {
            _logger = logger;
            _httpContextService = httpContextService;
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginResponse();
            var user = _context.Users
                .Include(i => i.Photo)
                .Where(w => w.UserName.ToLower() == request.UserName.ToLower() && w.Password == request.Password)
                .FirstOrDefault();

            user.LastLoginAtUtc = DateTime.Now;
            await _context.SaveChangesAsync(cancellationToken);

            var claimItems = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, request.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                    new Claim("User_Photo_ObjectKey", user.Photo.ObjectKey.ToString()),
            };

            switch (user.UserRole)
            {
                case Domain.AuthenticationUsers.User.UserRoles.AdminRole:
                    claimItems.Add(new Claim("CouncilId", 0.ToString()));
                    claimItems.Add(new Claim("CouncilName", "مجلس الجمعيات الأهلية"));
                    claimItems.Add(new Claim("CouncilObjectkey", Guid.Empty.ToString()));


                    response.ReturnUrl = "Administration";
                    break;
                case Domain.AuthenticationUsers.User.UserRoles.CouncilRole:
                    response.ReturnUrl = "AssociationsAffiliated";

                    var councilUser = _context.AssociationsAffiliatedWithTheCouncilUsers
                        .Include(i => i.AssociationsAffiliatedWithTheCouncil)
                        .Where(w => w.UserName == user.UserName)
                        .FirstOrDefault();
                    if (councilUser != null)
                    {
                        claimItems.Add(new Claim("CouncilId", councilUser.AssociationsAffiliatedWithTheCouncilId.ToString()));
                        claimItems.Add(new Claim("CouncilName", councilUser.AssociationsAffiliatedWithTheCouncil.Name));
                        claimItems.Add(new Claim("CouncilObjectkey", councilUser.AssociationsAffiliatedWithTheCouncil.objectkey.ToString()));
                    }
                    break;

                case Domain.AuthenticationUsers.User.UserRoles.Researcher:
                    response.ReturnUrl = "Researcher";

                    claimItems.Add(new Claim("CouncilId", 0.ToString()));
                    claimItems.Add(new Claim("CouncilName", "الباحثين"));
                    claimItems.Add(new Claim("CouncilObjectkey", Guid.Empty.ToString()));


                    break;
                default:
                    break;
            }


            await _httpContextService.SignIn(claimItems);
            return response;



        }



    }
}
