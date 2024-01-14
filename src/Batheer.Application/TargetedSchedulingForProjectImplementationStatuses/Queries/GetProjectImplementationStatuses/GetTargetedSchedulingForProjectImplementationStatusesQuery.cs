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

namespace Batheer.Application.TargetedSchedulingForProjectImplementationStatuses.Queries.GetProjectImplementationStatuses
{
    public class GetTargetedSchedulingForProjectImplementationStatusesQuery : IRequest<IEnumerable<TargetedSchedulingForProjectImplementationStatus>>
    {

    }
    public class GetTargetedSchedulingForProjectImplementationStatusesQueryHandler : IRequestHandler<GetTargetedSchedulingForProjectImplementationStatusesQuery, IEnumerable<TargetedSchedulingForProjectImplementationStatus>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTargetedSchedulingForProjectImplementationStatusesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTargetedSchedulingForProjectImplementationStatusesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TargetedSchedulingForProjectImplementationStatus>> Handle(GetTargetedSchedulingForProjectImplementationStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .TargetedSchedulingForProjectImplementationStatuses
                .ProjectTo<TargetedSchedulingForProjectImplementationStatus>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
