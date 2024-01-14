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

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResultsByFamilyObjectkey
{
    public class GetVisitingFamilyMemberResultsByFamilyObjectkeyQuery : IRequest<IEnumerable<VisitingFamilyMemberResultDto>>
    {
        public Guid FamilyObjectkey { get; }


        public GetVisitingFamilyMemberResultsByFamilyObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetVisitingFamilyMemberResultsByFamilyObjectkeyQueryHandler : IRequestHandler<GetVisitingFamilyMemberResultsByFamilyObjectkeyQuery, IEnumerable<VisitingFamilyMemberResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVisitingFamilyMemberResultsByFamilyObjectkeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyMemberResultsByFamilyObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<VisitingFamilyMemberResultDto>> Handle(GetVisitingFamilyMemberResultsByFamilyObjectkeyQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.VisitingFamilyMemberResults
                .Where(w => w.FamilyMember.Family.objectkey == request.FamilyObjectkey)
                .Include(a => a.FamilyMember.PersonalDataForm)
                .ProjectTo<VisitingFamilyMemberResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
