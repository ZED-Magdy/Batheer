using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetActivityTypes
{

    [Authorize]
    //[Authorize(Policy = "CanPurge")]
    // [Authorize(Policy = "CanPurge")]
    public class GetActivityTypesQuery : IRequest<IEnumerable<ActivityType>>
    {

    }
    public class GetActivityTypesQueryHandler : IRequestHandler<GetActivityTypesQuery, IEnumerable<ActivityType>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetActivityTypesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetActivityTypesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ActivityType>> Handle(GetActivityTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .ActivityTypes
                .AsNoTracking()
                .ProjectTo<ActivityType>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
