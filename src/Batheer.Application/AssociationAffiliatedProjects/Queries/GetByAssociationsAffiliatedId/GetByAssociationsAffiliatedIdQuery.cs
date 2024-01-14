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

namespace Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedId
{
    public class GetByAssociationsAffiliatedIdQuery : IRequest<IEnumerable<AssociationAffiliatedProject>>
    {
        public int AssociationsAffiliatedId { get; }

        public GetByAssociationsAffiliatedIdQuery(int associationsAffiliatedId)
        {
            AssociationsAffiliatedId = associationsAffiliatedId;
        }
    }

    public class GetByAssociationsAffiliatedIdQueryHandler : IRequestHandler<GetByAssociationsAffiliatedIdQuery, IEnumerable<AssociationAffiliatedProject>>
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

        public async Task<IEnumerable<AssociationAffiliatedProject>> Handle(GetByAssociationsAffiliatedIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.AssociationAffiliatedProjects
                .Where(w=> w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedId)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<AssociationAffiliatedProject>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
