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

namespace Batheer.Application.Modules.Lookups.Queries.GetFinanceTypes
{
    [Authorize]
    public class GetFinanceTypesQuery : IRequest<IEnumerable<FinanceType>>
    {

    }
    public class GetFinanceTypesQueryHandler : IRequestHandler<GetFinanceTypesQuery, IEnumerable<FinanceType>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFinanceTypesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFinanceTypesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<FinanceType>> Handle(GetFinanceTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .FinanceTypes
                .AsNoTracking()
                .ProjectTo<FinanceType>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
