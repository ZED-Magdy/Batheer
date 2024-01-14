using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResults
{
    public class GetVisitingFamilyMemberResultsQuery : IRequest<IEnumerable<VisitingFamilyMemberResultDto>>
    {
        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
        public string UserName { get; set; }
        public string IdentityNo { get; set; }

        public GetVisitingFamilyMemberResultsQuery()
        {
        }
    }

    public class GetVisitingFamilyMemberResultsQueryHandler : IRequestHandler<GetVisitingFamilyMemberResultsQuery, IEnumerable<VisitingFamilyMemberResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;


        public GetVisitingFamilyMemberResultsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyMemberResultsQuery> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<VisitingFamilyMemberResultDto>> Handle(GetVisitingFamilyMemberResultsQuery request, CancellationToken cancellationToken)
        {

            var query = _context.VisitingFamilyMemberResults
               .Include(a => a.FamilyMember.PersonalDataForm)
               .Select(s => s);

            if (string.IsNullOrEmpty(request.IdentityNo) == false)
            {
                query = query.Where(w => w.FamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo);
            }

            if (request.AssociationsAffiliatedWithTheCouncilId.HasValue)
            {
                query = query.Where(w => w.FamilyMember.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedWithTheCouncilId);
            }

            if (string.IsNullOrEmpty(request.UserName) == false)
            {
                query = query.Where(w => w.CreatedBy == request.UserName);
            }

            var result = await query
                .ProjectTo<VisitingFamilyMemberResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
