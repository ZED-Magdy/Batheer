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

namespace Batheer.Application.CouncilProjects.Queries.GetCouncilProjects
{
    public class GetCouncilProjectsQuery : IRequest<IEnumerable<CouncilProject>>
    {

    }
    public class GetCouncilProjectsQueryHandler : IRequestHandler<GetCouncilProjectsQuery, IEnumerable<CouncilProject>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCouncilProjectsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetCouncilProjectsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CouncilProject>> Handle(GetCouncilProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .CouncilProjects
                .ProjectTo<CouncilProject>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
