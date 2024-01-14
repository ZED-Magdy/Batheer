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

namespace Batheer.Application.Modules.Lookups.Queries.GetLoanTypes
{
    [Authorize]
    public class GetLoanTypesQuery : IRequest<IEnumerable<LoanType>>
    {

    }
    public class GetLoanTypesQueryHandler : IRequestHandler<GetLoanTypesQuery, IEnumerable<LoanType>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetLoanTypesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetLoanTypesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<LoanType>> Handle(GetLoanTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .LoanTypes
                .AsNoTracking()
                .ProjectTo<LoanType>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
