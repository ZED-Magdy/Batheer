using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetFamilyCategories
{
    [Authorize]
    public class GetFamilyCategoriesQuery : IRequest<IEnumerable<FamilyCategory>>
    {

    }
    public class GetFamilyCategoriesQueryHandler : IRequestHandler<GetFamilyCategoriesQuery, IEnumerable<FamilyCategory>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyCategoriesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FamilyCategory>> Handle(GetFamilyCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .FamilyCategories
                .AsNoTracking()
                .ProjectTo<FamilyCategory>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
