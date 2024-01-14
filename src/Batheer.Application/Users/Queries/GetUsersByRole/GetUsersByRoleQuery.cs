using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.Users.Queries.GetUsersByRole
{
    public class GetUsersByRoleQuery : IRequest<IEnumerable<UserDto>>
    {
        public UserRoles UserRole { get; }


        public GetUsersByRoleQuery(UserRoles userRole)
        {
            UserRole = userRole;
        }
    }

    public class GetUsersByRoleQueryHandler : IRequestHandler<GetUsersByRoleQuery, IEnumerable<UserDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetUsersByRoleQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetUsersByRoleQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _context.Users
                .Where(w => w.UserRole == request.UserRole)
                .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
