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

namespace Batheer.Application.Requests.BaseRequests.Queries.GetBaseRequestsForAssociationsAffiliatedWithTheCouncil
{
    /// <summary>
    /// جميع الطلبات الخاصة بالجمعية
    /// </summary>
    public class GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQuery : IRequest<IEnumerable<BaseRequestsForAssociationsAffiliatedWithTheCouncil>>
    {
        public GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQuery(int associationsAffiliatedWithTheCouncilId)
        {
            AssociationsAffiliatedWithTheCouncilId = associationsAffiliatedWithTheCouncilId;
        }
        public int AssociationsAffiliatedWithTheCouncilId { get; } 
    }

    public class GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQueryHandler : IRequestHandler<GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQuery, IEnumerable<BaseRequestsForAssociationsAffiliatedWithTheCouncil>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<BaseRequestsForAssociationsAffiliatedWithTheCouncil>> Handle(GetBaseRequestsForAssociationsAffiliatedWithTheCouncilQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .FamilyRegistrationRequests
                .Include(t => t.CouncilProject)
                .Include(t => t.Family.ResponsibleFamilyMember.PersonalDataForm)
                .Where(w => w.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedWithTheCouncilId)
                .ProjectTo<BaseRequestsForAssociationsAffiliatedWithTheCouncil>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
