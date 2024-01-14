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

namespace Batheer.Application.Modules.Lookups.Queries.GetRequestStatuses
{
    [Authorize]
    public class GetRequestStatusesQuery : IRequest<IEnumerable<RequestStatus>>
    {

    }
    public class GetRequestStatusesQueryHandler : IRequestHandler<GetRequestStatusesQuery, IEnumerable<RequestStatus>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRequestStatusesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetRequestStatusesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<RequestStatus>> Handle(GetRequestStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .RequestStatuses
                .AsNoTracking()
                .ProjectTo<RequestStatus>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
