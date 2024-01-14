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
    public class GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQuery : IRequest<IEnumerable<CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto>>
    {
    }

    public class GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQueryHandler : IRequestHandler<GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQuery, IEnumerable<CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto>> Handle(GetCitiesWithAssociationsAffiliatedWithTheCouncilInfosQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Cities
                .Include(a => a.Towns)
                .ThenInclude(a => a.AssociationsAffiliatedWithTheCouncilInfos)
                .ThenInclude(a => a.Classification)
                .Include(a => a.Towns)
                .ThenInclude(a => a.AssociationsAffiliatedWithTheCouncilInfos)
                    .ThenInclude(a => a.ActivityTypes)
                .ProjectTo<CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto>(_mapper.ConfigurationProvider)
                .ToListAsync();


            result.ForEach(city =>
            {
                city.Towns.ForEach(town =>
                {
                    town.AssociationsAffiliatedWithTheCouncilInfos.ForEach(info =>
                    {
                        var associationsAffiliatedWithTheCouncil = _context.AssociationsAffiliatedWithTheCouncils
                                   .Where(w => w.AssociationsAffiliatedWithTheCouncilInfoId == info.Id)
                                   .FirstOrDefault();

                        info.AssociationsAffiliatedWithTheCouncilId = associationsAffiliatedWithTheCouncil.Id;
                        info.AssociationsAffiliatedWithTheCouncilName = associationsAffiliatedWithTheCouncil.Name;
                    });
                });

            });
            return result;
        }

    }
}
