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

namespace Batheer.Application.Modules.Lookups.Queries.GetClassifications
{

    [Authorize]
    //[Authorize(Policy = "CanPurge")]
    // [Authorize(Policy = "CanPurge")]
    public class GetClassificationsQuery : IRequest<IEnumerable<Classification>>
    {

    }
    public class GetClassificationsQueryHandler : IRequestHandler<GetClassificationsQuery, IEnumerable<Classification>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetClassificationsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetClassificationsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Classification>> Handle(GetClassificationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Classifications
                .AsNoTracking()
                .ProjectTo<Classification>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
