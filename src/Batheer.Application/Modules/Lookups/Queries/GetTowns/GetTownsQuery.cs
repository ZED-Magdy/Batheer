using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Security;
using Batheer.Application.Modules.Lookups.Queries.GetCities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetTowns
{

    [Authorize]
    //[Authorize(Policy = "CanPurge")]
    // [Authorize(Policy = "CanPurge")]
    public class GetTownsQuery : IRequest<IEnumerable<TownDto>>
    {

    }
    public class GetTownsQueryHandler : IRequestHandler<GetTownsQuery, IEnumerable<TownDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTownsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTownsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TownDto>> Handle(GetTownsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Towns
                .Include(i=> i.City)
                .AsNoTracking()
                .ProjectTo<TownDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
