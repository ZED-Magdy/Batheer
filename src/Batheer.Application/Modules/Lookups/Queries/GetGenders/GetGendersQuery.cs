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

namespace Batheer.Application.Modules.Lookups.Queries.GetGenders
{
    [Authorize]
    public class GetGendersQuery : IRequest<IEnumerable<Gender>>
    {

    }
    public class GetGendersQueryHandler : IRequestHandler<GetGendersQuery, IEnumerable<Gender>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetGendersQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetGendersQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Gender>> Handle(GetGendersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Genders
                .AsNoTracking()
                .ProjectTo<Gender>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
