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


namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetByAssociationsAffiliatedId
{
    public class GetByAssociationsAffiliatedIdQuery : IRequest<IEnumerable<TargetedSchedulingForProjectImplementation>>
    {
        public GetByAssociationsAffiliatedIdQuery(int associationsAffiliatedId)
        {
            AssociationsAffiliatedId = associationsAffiliatedId;
        }

        public int AssociationsAffiliatedId { get; }
    }
    public class GetByAssociationsAffiliatedIdQueryHandler : IRequestHandler<GetByAssociationsAffiliatedIdQuery, IEnumerable<TargetedSchedulingForProjectImplementation>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByAssociationsAffiliatedIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByAssociationsAffiliatedIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TargetedSchedulingForProjectImplementation>> Handle(GetByAssociationsAffiliatedIdQuery request, CancellationToken cancellationToken)
        {

            var result = await _context
                .TargetedSchedulingForProjectImplementations
                .Include(t => t.AssociationAffiliatedProject)
                .ThenInclude(t => t.CouncilProject)
                .Include(t => t.TargetedSchedulingForProjectImplementationStatus)
                .Where(w => w.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                //.OrderBy(o => o.FullName)
                .ProjectTo<TargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
