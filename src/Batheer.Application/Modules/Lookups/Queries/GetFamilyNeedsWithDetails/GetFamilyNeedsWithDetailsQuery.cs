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

namespace Batheer.Application.Modules.Lookups.Queries.GetFamilyNeedsWithDetails
{
    [Authorize]
    public class GetFamilyNeedsWithDetailsQuery : IRequest<IEnumerable<FamilyNeedWithDetails>>
    {

    }
    public class GetFamilyNeedsWithDetailsQueryHandler : IRequestHandler<GetFamilyNeedsWithDetailsQuery, IEnumerable<FamilyNeedWithDetails>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyNeedsWithDetailsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyNeedsWithDetailsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FamilyNeedWithDetails>> Handle(GetFamilyNeedsWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .FamilyNeeds
                .Include(i=> i.FamilyNeedDetails)
                .AsNoTracking()
                .ProjectTo<FamilyNeedWithDetails>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
