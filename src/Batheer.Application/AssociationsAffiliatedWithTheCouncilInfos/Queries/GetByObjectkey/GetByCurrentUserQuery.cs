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
    public class GetByCurrentUserQuery : IRequest<AssociationsAffiliatedWithTheCouncilInfoDto>
    {
        public GetByCurrentUserQuery()
        {
        }
    }

    public class GetByCurrentUserQueryHandler : IRequestHandler<GetByCurrentUserQuery, AssociationsAffiliatedWithTheCouncilInfoDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;


        public GetByCurrentUserQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByCurrentUserQuery> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<AssociationsAffiliatedWithTheCouncilInfoDto> Handle(GetByCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var associationsAffiliatedWithTheCouncil = await _context.AssociationsAffiliatedWithTheCouncils
               .Where(w => w.Id == _currentUserService.CouncilId)
               .FirstOrDefaultAsync();

            if (associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfoId is null)
                return null;

            var result = await _context.AssociationsAffiliatedWithTheCouncilInfos
                .Include(a => a.Classification)
                .Include(a => a.ActivityTypes)
                .Include(a => a.Town)
                .ThenInclude(a => a.City)
                .Where(w => w.Id == associationsAffiliatedWithTheCouncil.AssociationsAffiliatedWithTheCouncilInfoId)
                .ProjectTo<AssociationsAffiliatedWithTheCouncilInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
