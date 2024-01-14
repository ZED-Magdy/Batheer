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

namespace Batheer.Application.Modules.Lookups.Queries.GetMaritalStatuses
{
    [Authorize]
    public class GetMaritalStatusesQuery : IRequest<IEnumerable<MaritalStatus>>
    {

    }
    public class GetMaritalStatusesQueryHandler : IRequestHandler<GetMaritalStatusesQuery, IEnumerable<MaritalStatus>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetMaritalStatusesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetMaritalStatusesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MaritalStatus>> Handle(GetMaritalStatusesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .MaritalStatuses
                .AsNoTracking()
                .ProjectTo<MaritalStatus>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}

