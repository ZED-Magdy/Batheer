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

namespace Batheer.Application.Modules.Lookups.Queries.GetSupportingFamilyTypes
{
    [Authorize]
    public class GetSupportingFamilyTypesQuery : IRequest<IEnumerable<SupportingFamilyType>>
    {

    }
    public class GetSupportingFamilyTypesQueryHandler : IRequestHandler<GetSupportingFamilyTypesQuery, IEnumerable<SupportingFamilyType>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetSupportingFamilyTypesQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetSupportingFamilyTypesQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<SupportingFamilyType>> Handle(GetSupportingFamilyTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .SupportingFamilyTypes
                .AsNoTracking()
                .ProjectTo<SupportingFamilyType>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }

    }
}
