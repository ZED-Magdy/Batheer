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

namespace Batheer.Application.Modules.Lookups.Queries.GetEducationalLevels
{
    [Authorize]
    public class GetEducationalLevelsQuery : IRequest<IEnumerable<EducationalLevel>>
    {

    }
    public class GetEducationalLevelsQueryHandler : IRequestHandler<GetEducationalLevelsQuery, IEnumerable<EducationalLevel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetEducationalLevelsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetEducationalLevelsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<EducationalLevel>> Handle(GetEducationalLevelsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .EducationalLevels
                .AsNoTracking()
                .ProjectTo<EducationalLevel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
