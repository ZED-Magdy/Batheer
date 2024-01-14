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

namespace Batheer.Application.Modules.Lookups.Queries.GetHealthStatuses
{
    [Authorize]
    public class GetHealthStatusesQuery : IRequest<IEnumerable<HealthStatus>>
    {

    }
    public class GetHealthStatusesQueryHandler : IRequestHandler<GetHealthStatusesQuery, IEnumerable<HealthStatus>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetHealthStatusesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetHealthStatusesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<HealthStatus>> Handle(GetHealthStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .HealthStatuses
                .AsNoTracking()
                .ProjectTo<HealthStatus>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
