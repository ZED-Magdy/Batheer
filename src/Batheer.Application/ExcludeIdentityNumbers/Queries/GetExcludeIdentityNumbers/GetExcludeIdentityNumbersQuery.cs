using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Mappings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.ExcludeIdentityNumbers.Queries.GetExcludeIdentityNumbers
{
    public class GetExcludeIdentityNumbersQuery : IRequest<IEnumerable<ExcludeIdentityNumberDto>>
    {
        public string IdentityNo { get; set; }
        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
    }

    public class GetExcludeIdentityNumbersQueryHandler : IRequestHandler<GetExcludeIdentityNumbersQuery, IEnumerable<ExcludeIdentityNumberDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetExcludeIdentityNumbersQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetExcludeIdentityNumbersQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<ExcludeIdentityNumberDto>> Handle(GetExcludeIdentityNumbersQuery request, CancellationToken cancellationToken)
        {

            //var result = await _context.ExcludeIdentityNumbers
            //    .ProjectTo<ExcludeIdentityNumberDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);

            //return result;


            var parameters = new
            {
                request.IdentityNo,
                request.AssociationsAffiliatedWithTheCouncilId
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);


            var result = _queryExecuter.Query<ExcludeIdentityNumberDto>(
                "EXEC [dbo].[SP_GetExcludeIdentityNumbers] " +
                string.Join(',', paramNames),
                parameters);


            return result;
        }

    }
}
