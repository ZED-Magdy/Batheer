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

namespace Batheer.Application.Modules.Lookups.Queries.GetProducedFamilyProducts
{
    [Authorize]
    public class GetProducedFamilyProductsQuery : IRequest<IEnumerable<ProducedFamilyProduct>>
    {

    }
    public class GetProducedFamilyProductsQueryHandler : IRequestHandler<GetProducedFamilyProductsQuery, IEnumerable<ProducedFamilyProduct>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetProducedFamilyProductsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetProducedFamilyProductsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProducedFamilyProduct>> Handle(GetProducedFamilyProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .ProducedFamilyProducts
                .AsNoTracking()
                .ProjectTo<ProducedFamilyProduct>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
