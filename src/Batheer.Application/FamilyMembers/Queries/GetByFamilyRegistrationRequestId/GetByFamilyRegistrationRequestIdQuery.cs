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

namespace Batheer.Application.FamilyMembers.Queries.GetByFamilyRegistrationRequestId
{
    public class GetByFamilyRegistrationRequestIdQuery : IRequest<IEnumerable<FamilyMemberDto>>
    {
        public int FamilyRegistrationRequestId { get; }


        public GetByFamilyRegistrationRequestIdQuery(int familyRegistrationRequestId)
        {
            FamilyRegistrationRequestId = familyRegistrationRequestId;
        }
    }

    public class GetByFamilyRegistrationRequestIdQueryHandler : IRequestHandler<GetByFamilyRegistrationRequestIdQuery, IEnumerable<FamilyMemberDto>>
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

        public async Task<IEnumerable<FamilyMemberDto>> Handle(GetByFamilyRegistrationRequestIdQuery request, CancellationToken cancellationToken)
        {
            var result1 = await _context.FamilyRegistrationRequests
               .Where(w => w.Id == request.FamilyRegistrationRequestId)
               .Include(a => a.Family)
               .ThenInclude(a => a.FamilyMembers)
               .ToListAsync();


            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Id == request.FamilyRegistrationRequestId)
                .Include(a => a.Family)
                .ThenInclude(a => a.FamilyMembers)
                .SelectMany(s=> s.Family.FamilyMembers)
                .ProjectTo<FamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
