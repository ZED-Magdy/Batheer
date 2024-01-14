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

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncils.Queries.GetAssociationsAffiliatedWithTheCouncils
{
    public class GetAssociationsAffiliatedWithTheCouncilsQuery : IRequest<IEnumerable<AssociationsAffiliatedWithTheCouncil>>
    {
    }

    public class GetAssociationsAffiliatedWithTheCouncilsQueryHandler : IRequestHandler<GetAssociationsAffiliatedWithTheCouncilsQuery, IEnumerable<AssociationsAffiliatedWithTheCouncil>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAssociationsAffiliatedWithTheCouncilsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAssociationsAffiliatedWithTheCouncilsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AssociationsAffiliatedWithTheCouncil>> Handle(GetAssociationsAffiliatedWithTheCouncilsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .AssociationsAffiliatedWithTheCouncils
                .OrderBy(o => o.Name)
                .ProjectTo<AssociationsAffiliatedWithTheCouncil>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
