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

namespace Batheer.Application.Modules.Lookups.Queries.GetMonthlyIncomes
{
    [Authorize]
    public class GetMonthlyIncomesQuery : IRequest<IEnumerable<MonthlyIncome>>
    {

    }
    public class GetMonthlyIncomesQueryHandler : IRequestHandler<GetMonthlyIncomesQuery, IEnumerable<MonthlyIncome>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetMonthlyIncomesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetMonthlyIncomesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MonthlyIncome>> Handle(GetMonthlyIncomesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .MonthlyIncomes
                .AsNoTracking()
                .ProjectTo<MonthlyIncome>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}

