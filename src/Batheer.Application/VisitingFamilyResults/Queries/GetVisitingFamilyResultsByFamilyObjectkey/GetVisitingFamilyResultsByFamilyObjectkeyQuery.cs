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

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByFamilyObjectkey
{
    public class GetVisitingFamilyResultsByFamilyObjectkeyQuery : IRequest<IEnumerable<VisitingFamilyResultDto>>
    {
        public Guid FamilyObjectkey { get; }


        public GetVisitingFamilyResultsByFamilyObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetVisitingFamilyResultsByFamilyObjectkeyQueryHandler : IRequestHandler<GetVisitingFamilyResultsByFamilyObjectkeyQuery, IEnumerable<VisitingFamilyResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetVisitingFamilyResultsByFamilyObjectkeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyResultsByFamilyObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<VisitingFamilyResultDto>> Handle(GetVisitingFamilyResultsByFamilyObjectkeyQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.VisitingFamilyResults
                .Where(w => w.Family.objectkey == request.FamilyObjectkey)
                .Include(a => a.Family.ResponsibleFamilyMember.PersonalDataForm)
                .ProjectTo<VisitingFamilyResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
