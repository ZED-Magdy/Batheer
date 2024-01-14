using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResults
{
    public class GetVisitingFamilyResultsQuery : IRequest<IEnumerable<VisitingFamilyResultDto>>
    {
        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
        public string UserName { get; set; }
        public string IdentityNo { get; set; }
    }

    public class GetVisitingFamilyResultsQueryHandler : IRequestHandler<GetVisitingFamilyResultsQuery, IEnumerable<VisitingFamilyResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;


        public GetVisitingFamilyResultsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyResultsQuery> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<VisitingFamilyResultDto>> Handle(GetVisitingFamilyResultsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.VisitingFamilyResults
               .Include(a => a.Family.ResponsibleFamilyMember.PersonalDataForm)
               .Select(s => s);

            if (string.IsNullOrEmpty(request.IdentityNo) == false)
            {
                query = query.Where(w => w.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == request.IdentityNo);
            }

            if (request.AssociationsAffiliatedWithTheCouncilId.HasValue)
            {
                query = query.Where(w => w.Family.FamilyRegistrationRequest.AssociationsAffiliatedWithTheCouncilId == request.AssociationsAffiliatedWithTheCouncilId);
            }

            if (string.IsNullOrEmpty(request.UserName) == false)
            {
                query = query.Where(w => w.CreatedBy == request.UserName);
            }

            var result = await query
                .ProjectTo<VisitingFamilyResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
