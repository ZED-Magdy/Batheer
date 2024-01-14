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

namespace Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedIdAndcouncilProjectId
{
    public class GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery : IRequest<IEnumerable<AssociationAffiliatedProject>>
    {
        public int AssociationsAffiliatedId { get; }
        public int CouncilProjectId { get; }

        public GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery(int associationsAffiliatedId, int councilProjectId)
        {
            AssociationsAffiliatedId = associationsAffiliatedId;
            CouncilProjectId = councilProjectId;
        }
    }

    public class GetByAssociationsAffiliatedIdAndcouncilProjectIdQueryHandler : IRequestHandler<GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery, IEnumerable<AssociationAffiliatedProject>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByAssociationsAffiliatedIdAndcouncilProjectIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AssociationAffiliatedProject>> Handle(GetByAssociationsAffiliatedIdAndcouncilProjectIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.AssociationAffiliatedProjects
                .Where(w=> w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                .Where(w=> w.CouncilProjectId == request.CouncilProjectId)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<AssociationAffiliatedProject>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
