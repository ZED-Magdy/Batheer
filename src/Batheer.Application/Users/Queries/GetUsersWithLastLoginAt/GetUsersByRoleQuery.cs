using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.ExcludeIdentityNumbers.Queries.GetExcludeIdentityNumbers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Batheer.Domain.AuthenticationUsers.User;

namespace Batheer.Application.Users.Queries.GetUsersWithLastLoginAt
{
    public class GetUsersWithLastLoginAtQuery : IRequest<IEnumerable<UsersWithLastLoginAtDto>>
    {
        public GetUsersWithLastLoginAtQuery()
        {
        }
    }

    public class GetUsersWithLastLoginAtQueryHandler : IRequestHandler<GetUsersWithLastLoginAtQuery, IEnumerable<UsersWithLastLoginAtDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetUsersWithLastLoginAtQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetUsersWithLastLoginAtQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<UsersWithLastLoginAtDto>> Handle(GetUsersWithLastLoginAtQuery request, CancellationToken cancellationToken)
        {
            var parameters = new
            {
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            var result = _queryExecuter.Query<UsersWithLastLoginAtDto>(
                "EXEC [dbo].[sp_GetUsersWithLastLoginAtUtc] " +
                string.Join(',', paramNames),
                parameters);


            return result;
        }

    }
}
