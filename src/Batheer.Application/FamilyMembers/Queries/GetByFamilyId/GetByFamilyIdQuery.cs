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

namespace Batheer.Application.FamilyMembers.Queries.GetByFamilyId
{
    public class GetByFamilyIdQuery : IRequest<IEnumerable<FamilyMemberDto>>
    {
        public int FamilyId { get; }


        public GetByFamilyIdQuery(int familyId)
        {
            FamilyId = familyId;
        }
    }

    public class GetByFamilyIdQueryHandler : IRequestHandler<GetByFamilyIdQuery, IEnumerable<FamilyMemberDto>>
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

        public async Task<IEnumerable<FamilyMemberDto>> Handle(GetByFamilyIdQuery request, CancellationToken cancellationToken)
        {
            var result1 = await _context.FamilyRegistrationRequests
               .Where(w => w.Id == request.FamilyId)
               .Include(a => a.Family)
               .ThenInclude(a => a.FamilyMembers)
               .ToListAsync();


            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Id == request.FamilyId)
                .Include(a => a.Family)
                .ThenInclude(a => a.FamilyMembers)
                .SelectMany(s=> s.Family.FamilyMembers)
                .ProjectTo<FamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
