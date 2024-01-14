using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Domain.AssociationAffiliatedProjects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Batheer.Domain.AssociationAffiliatedProjects.Lookups.FamilyCategory;

namespace Batheer.Application.Summaries.Queries.GetFamilyCategoriesCount
{
    public class GetFamilyCategoriesCountQuery : IRequest<List<FamilyCategoriesCountDto>>
    {
        public int? CouncilId { get; }
        public GetFamilyCategoriesCountQuery(int? councilId)
        {
            CouncilId = councilId;
        }
    }
    public class GetFamilyCategoriesCountQueryHandler : IRequestHandler<GetFamilyCategoriesCountQuery, List<FamilyCategoriesCountDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyCategoriesCountQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyCategoriesCountQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<FamilyCategoriesCountDto>> Handle(GetFamilyCategoriesCountQuery request, CancellationToken cancellationToken)
        {

            Func<FamilyRegistrationRequest, bool> _expression;

            if (request.CouncilId.HasValue)
                _expression = i => { return i.AssociationsAffiliatedWithTheCouncilId == request.CouncilId.Value; };
            else
                _expression = i => { return true; };

            var items = new List<FamilyCategoriesCountDto>();


            items.Add(new FamilyCategoriesCountDto()
            {
                Key = 0,
                Value = _context.FamilyRegistrationRequests
                                .Include(f=> f.Family)
                                .Where(_expression)
                                .Where(w => w.FamilyCategoryId == (int)FamilyCategories.Widow)
                                .Count()
            });


            items.Add(new FamilyCategoriesCountDto()
            {
                Key = 1,
                Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family)
                                .Where(_expression)
                                .Where(w => w.FamilyCategoryId == (int)FamilyCategories.Divorced)
                                .Count()
            });


            items.Add(new FamilyCategoriesCountDto()
            {
                Key = 2,
                Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family)
                                .Where(_expression)
                                .Where(w => w.FamilyCategoryId == (int)FamilyCategories.Poor)
                                .Count()
            });



            items.Add(
                new FamilyCategoriesCountDto()
                {
                    Key = 3,
                    Value = _context.FamilyRegistrationRequests
                                .Include(f => f.Family)
                                .Where(_expression)
                                .Where(w => w.FamilyCategoryId == (int)FamilyCategories.Orphan)
                                .Count()
                });


            return items;
        }

    }
}
