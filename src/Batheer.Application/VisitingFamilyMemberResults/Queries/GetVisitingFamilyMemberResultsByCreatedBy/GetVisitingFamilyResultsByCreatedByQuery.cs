using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyResultsByCreatedBy;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResultsByCreatedBy
{
    public class GetVisitingFamilyMemberResultsByCreatedByQuery : IRequest<IEnumerable<VisitingFamilyMemberResultDto>>
    {
        public GetVisitingFamilyMemberResultsByCreatedByQuery()
        {
        }
    }

    public class GetVisitingFamilyMemberResultsByCreatedByQueryHandler : IRequestHandler<GetVisitingFamilyMemberResultsByCreatedByQuery, IEnumerable<VisitingFamilyMemberResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;


        public GetVisitingFamilyMemberResultsByCreatedByQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyMemberResultsByCreatedByQuery> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<VisitingFamilyMemberResultDto>> Handle(GetVisitingFamilyMemberResultsByCreatedByQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.VisitingFamilyMemberResults
                .Where(w => w.CreatedBy == _currentUserService.UserId)
                .Include(a => a.FamilyMember.PersonalDataForm)
                .ProjectTo<VisitingFamilyMemberResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
