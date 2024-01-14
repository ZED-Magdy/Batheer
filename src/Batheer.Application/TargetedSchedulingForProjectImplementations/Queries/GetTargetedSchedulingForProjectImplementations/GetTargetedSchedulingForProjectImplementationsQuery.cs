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


namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetTargetedSchedulingForProjectImplementations
{
    public class GetTargetedSchedulingForProjectImplementationsQuery : IRequest<IEnumerable<TargetedSchedulingForProjectImplementation>>
    {

    }
    public class GetTargetedSchedulingForProjectImplementationsQueryHandler : IRequestHandler<GetTargetedSchedulingForProjectImplementationsQuery, IEnumerable<TargetedSchedulingForProjectImplementation>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTargetedSchedulingForProjectImplementationsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTargetedSchedulingForProjectImplementationsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TargetedSchedulingForProjectImplementation>> Handle(GetTargetedSchedulingForProjectImplementationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .TargetedSchedulingForProjectImplementations
                .Include(t => t.AssociationAffiliatedProject.CouncilProject)
                .Include(t => t.TargetedSchedulingForProjectImplementationStatus)
                //.OrderBy(o => o.FullName)
                .ProjectTo<TargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
