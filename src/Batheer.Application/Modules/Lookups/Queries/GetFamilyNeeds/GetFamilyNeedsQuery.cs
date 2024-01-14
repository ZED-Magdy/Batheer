using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetFamilyNeeds
{
    [Authorize]
    public class GetFamilyNeedsQuery : IRequest<IEnumerable<FamilyNeed>>
    {

    }
    public class GetFamilyNeedsQueryHandler : IRequestHandler<GetFamilyNeedsQuery, IEnumerable<FamilyNeed>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyNeedsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyNeedsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FamilyNeed>> Handle(GetFamilyNeedsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .FamilyNeeds
                .AsNoTracking()
                .ProjectTo<FamilyNeed>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
