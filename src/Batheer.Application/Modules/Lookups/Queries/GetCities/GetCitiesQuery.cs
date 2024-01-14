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

namespace Batheer.Application.Modules.Lookups.Queries.GetCities
{

    [Authorize]
    //[Authorize(Policy = "CanPurge")]
    // [Authorize(Policy = "CanPurge")]
    public class GetCitiesQuery : IRequest<IEnumerable<CityDto>>
    {

    }
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, IEnumerable<CityDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetCitiesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CityDto>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Cities
                .AsNoTracking()
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
