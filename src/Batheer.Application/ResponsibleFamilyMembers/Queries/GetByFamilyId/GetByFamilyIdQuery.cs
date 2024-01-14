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
namespace Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyId
{
    public class GetByFamilyIdQuery : IRequest<ResponsibleFamilyMemberDto>
    {
        public int FamilyId { get; }

        public GetByFamilyIdQuery(int familyId)
        {
            FamilyId = familyId;
        }
    }

    public class GetByFamilyIdQueryHandler : IRequestHandler<GetByFamilyIdQuery, ResponsibleFamilyMemberDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByFamilyIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByFamilyIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponsibleFamilyMemberDto> Handle(GetByFamilyIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.FamilyId == request.FamilyId)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<ResponsibleFamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
