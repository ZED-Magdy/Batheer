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
namespace Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyRegistrationRequestId
{
    public class GetByFamilyRegistrationRequestIdQuery : IRequest<ResponsibleFamilyMemberDto>
    {
        public int FamilyRegistrationRequestId { get; }

        public GetByFamilyRegistrationRequestIdQuery(int familyRegistrationRequestId)
        {
            FamilyRegistrationRequestId = familyRegistrationRequestId;
        }
    }

    public class GetByFamilyRegistrationRequestIdQueryHandler : IRequestHandler<GetByFamilyRegistrationRequestIdQuery, ResponsibleFamilyMemberDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByFamilyRegistrationRequestIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByFamilyRegistrationRequestIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ResponsibleFamilyMemberDto> Handle(GetByFamilyRegistrationRequestIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Id == request.FamilyRegistrationRequestId)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<ResponsibleFamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
