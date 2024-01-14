using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationAffiliatedProjects.Queries.GetAssociationAffiliatedProjects
{
    public class GetAssociationAffiliatedProjectsQuery : IRequest<IEnumerable<AssociationAffiliatedProject>>
    {
    }

    public class GetAssociationAffiliatedProjectsQueryHandler : IRequestHandler<GetAssociationAffiliatedProjectsQuery, IEnumerable<AssociationAffiliatedProject>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetAssociationAffiliatedProjectsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAssociationAffiliatedProjectsQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<AssociationAffiliatedProject>> Handle(GetAssociationAffiliatedProjectsQuery request, CancellationToken cancellationToken)
        {
            //var result = await _context.AssociationAffiliatedProjects
            //    .Include(a => a.AssociationsAffiliatedWithTheCouncil)
            //    .Include(a => a.CouncilProject)
            //    .ProjectTo<AssociationAffiliatedProject>(_mapper.ConfigurationProvider)
            //    .ToListAsync();
            //return result;

            var query = @"
select AssociationsAffiliatedWithTheCouncilId 
,cp.Name CouncilProjectName
, c.Name AssociationsAffiliatedWithTheCouncilName
, p.ProjectName
, CouncilProjectId
, AssociationAffiliatedProjectId
, s.id TargetedSchedulingForProjectImplementationId
, s.FromDate
, s.ToDate
, s.ApprovedDate
,s.ApprovedBy
,ts.Name ImplementationStatusName
from dbo.AssociationAffiliatedProjects p
inner join dbo.AssociationsAffiliatedWithTheCouncils c on c.Id = p.AssociationsAffiliatedWithTheCouncilId
inner join dbo.CouncilProjects cp on cp.id = p.CouncilProjectId
inner join dbo.TargetedSchedulingForProjectImplementations s on s.AssociationAffiliatedProjectId = p.Id
inner join dbo.TargetedSchedulingForProjectImplementationStatuses ts on ts.Id = s.TargetedSchedulingForProjectImplementationStatusId
";

            return _queryExecuter.Query<AssociationAffiliatedProject>(query);

        }

    }
}
