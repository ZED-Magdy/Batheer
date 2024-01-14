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

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetAssociationsAffiliatedWithTheCouncilInfos
{
    public class GetAssociationsAffiliatedWithTheCouncilInfosQuery : IRequest<IEnumerable<AssociationsAffiliatedWithTheCouncilInfoDto>>
    {
    }

    public class GetAssociationsAffiliatedWithTheCouncilInfosQueryHandler : IRequestHandler<GetAssociationsAffiliatedWithTheCouncilInfosQuery, IEnumerable<AssociationsAffiliatedWithTheCouncilInfoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetAssociationsAffiliatedWithTheCouncilInfosQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetAssociationsAffiliatedWithTheCouncilInfosQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<AssociationsAffiliatedWithTheCouncilInfoDto>> Handle(GetAssociationsAffiliatedWithTheCouncilInfosQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.AssociationsAffiliatedWithTheCouncilInfos
                .Include(a => a.Classification)
                .Include(a => a.ActivityTypes)
                .Include(a=> a.Town)
                .ThenInclude(a=> a.City)
                .ProjectTo<AssociationsAffiliatedWithTheCouncilInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();


            result.ForEach(info =>
            {
                var associationsAffiliatedWithTheCouncil = _context.AssociationsAffiliatedWithTheCouncils
                                .Where(w => w.AssociationsAffiliatedWithTheCouncilInfoId == info.Id)
                                .FirstOrDefault();

                info.AssociationsAffiliatedWithTheCouncilId = associationsAffiliatedWithTheCouncil.Id;
                info.AssociationsAffiliatedWithTheCouncilName = associationsAffiliatedWithTheCouncil.Name;
            });
            return result;
        }

    }
}
