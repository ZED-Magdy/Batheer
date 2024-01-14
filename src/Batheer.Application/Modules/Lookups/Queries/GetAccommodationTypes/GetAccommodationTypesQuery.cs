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

namespace Batheer.Application.Modules.Lookups.Queries.GetAccommodationTypes
{

    [Authorize]
    //[Authorize(Policy = "CanPurge")]
    // [Authorize(Policy = "CanPurge")]
    public class GetAccommodationTypesQuery : IRequest<IEnumerable<AccommodationType>>
    {

    }
    public class GetAccommodationTypesQueryHandler : IRequestHandler<GetAccommodationTypesQuery, IEnumerable<AccommodationType>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetAccommodationTypesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAccommodationTypesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AccommodationType>> Handle(GetAccommodationTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .AccommodationTypes
                .AsNoTracking()
                .ProjectTo<AccommodationType>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
