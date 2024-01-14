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

namespace Batheer.Application.FamilyMembers.Queries.GetByFamilyObjectkey
{
    public class GetByFamilyObjectkeyQuery : IRequest<IEnumerable<FamilyMemberDto>>
    {
        public Guid FamilyObjectkey { get; }


        public GetByFamilyObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetByFamilyObjectkeyQueryHandler : IRequestHandler<GetByFamilyObjectkeyQuery, IEnumerable<FamilyMemberDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByFamilyObjectkeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByFamilyObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FamilyMemberDto>> Handle(GetByFamilyObjectkeyQuery request, CancellationToken cancellationToken)
        {
            //var result1 = await _context.FamilyRegistrationRequests
            //   .Where(w => w.Id == request.FamilyId)
            //   .Include(a => a.Family)
            //   .ThenInclude(a => a.FamilyMembers)
            //   .ToListAsync();


            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Family.objectkey == request.FamilyObjectkey)
                .Include(a => a.Family)
                .ThenInclude(a => a.FamilyMembers)
                .SelectMany(s=> s.Family.FamilyMembers)
                .ProjectTo<FamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
