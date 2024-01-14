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

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetByObjectkey
{
    public class GetByObjectkeyQuery : IRequest<AssociationsAffiliatedWithTheCouncilInfoDto>
    {
        public Guid Objectkey { get; }

        public GetByObjectkeyQuery(Guid objectkey)
        {
            Objectkey = objectkey;
        }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByObjectkeyQuery, AssociationsAffiliatedWithTheCouncilInfoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AssociationsAffiliatedWithTheCouncilInfoDto> Handle(GetByObjectkeyQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.AssociationsAffiliatedWithTheCouncilInfos
                .Where(w => w.objectkey == request.Objectkey)
                .Include(a => a.Classification)
                .Include(a => a.ActivityTypes)
                .ThenInclude(a => a.ActivityType)
                .Include(a => a.Town)
                .ThenInclude(a => a.City)
                .ProjectTo<AssociationsAffiliatedWithTheCouncilInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
