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

namespace Batheer.Application.Modules.Lookups.Queries.GetOccupations
{
    [Authorize]
    public class GetOccupationsQuery : IRequest<IEnumerable<Occupation>>
    {

    }
    public class GetOccupationsQueryHandler : IRequestHandler<GetOccupationsQuery, IEnumerable<Occupation>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetOccupationsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetOccupationsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Occupation>> Handle(GetOccupationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Occupations
                .AsNoTracking()
                .ProjectTo<Occupation>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
