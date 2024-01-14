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
namespace Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyObjectkey
{
    public class GetByFamilyObjectkeyQuery : IRequest<ResponsibleFamilyMemberDto>
    {
        public Guid FamilyObjectkey { get; }

        public GetByFamilyObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetByFamilyObjectkeyQueryHandler : IRequestHandler<GetByFamilyObjectkeyQuery, ResponsibleFamilyMemberDto>
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

        public async Task<ResponsibleFamilyMemberDto> Handle(GetByFamilyObjectkeyQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Family.objectkey == request.FamilyObjectkey)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<ResponsibleFamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
