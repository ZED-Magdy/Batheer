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


namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Queries.GetAssociationsAffiliatedWithTheCouncilUsers
{
    public class GetAssociationsAffiliatedWithTheCouncilUsersQuery : IRequest<IEnumerable<AssociationsAffiliatedWithTheCouncilUser>>
    {
    }

    public class GetAssociationsAffiliatedWithTheCouncilUsersQueryHandler : IRequestHandler<GetAssociationsAffiliatedWithTheCouncilUsersQuery, IEnumerable<AssociationsAffiliatedWithTheCouncilUser>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAssociationsAffiliatedWithTheCouncilUsersQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAssociationsAffiliatedWithTheCouncilUsersQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AssociationsAffiliatedWithTheCouncilUser>> Handle(GetAssociationsAffiliatedWithTheCouncilUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .AssociationsAffiliatedWithTheCouncilUsers
                .OrderBy(o => o.FullName)
                .ProjectTo<AssociationsAffiliatedWithTheCouncilUser>(_mapper.ConfigurationProvider)
                .ToListAsync();

            result.ForEach(r =>
            {
                var u = _context.Users
                    .Include(i => i.Photo)
                    .Where(w => w.UserName == r.UserName)
                    .FirstOrDefault();
                if (u is not null && u.Photo is not null)
                {
                    r.PhotoObjectkey = u.Photo.ObjectKey;
                }
            });

            return result;
        }

    }
}
