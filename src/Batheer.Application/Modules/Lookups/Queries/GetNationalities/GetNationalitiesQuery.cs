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

namespace Batheer.Application.Modules.Lookups.Queries.GetNationalities
{
    [Authorize]
    public class GetNationalitiesQuery : IRequest<IEnumerable<Nationality>>
    {

    }
    public class GetNationalitiesQueryHandler : IRequestHandler<GetNationalitiesQuery, IEnumerable<Nationality>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetNationalitiesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetNationalitiesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Nationality>> Handle(GetNationalitiesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Nationalities
                .AsNoTracking()
                .ProjectTo<Nationality>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
