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


namespace Batheer.Application.Reports.Queries.GetSummaryForAssociationsAffiliatedId
{
    public class GetSummaryForAssociationsAffiliatedIdQuery : IRequest<IEnumerable<SummaryForAssociationsAffiliatedIdDto>>
    {
        public GetSummaryForAssociationsAffiliatedIdQuery()
        {
        }

        public int AssociationsAffiliatedId { get; set; }
    }
    public class GetSummaryForAssociationsAffiliatedIdQueryHandler : IRequestHandler<GetSummaryForAssociationsAffiliatedIdQuery, IEnumerable<SummaryForAssociationsAffiliatedIdDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IQueryExecuter _queryExecuter;

        public GetSummaryForAssociationsAffiliatedIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetSummaryForAssociationsAffiliatedIdQuery> logger, IQueryExecuter queryExecuter)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _queryExecuter = queryExecuter;
        }

        public async Task<IEnumerable<SummaryForAssociationsAffiliatedIdDto>> Handle(GetSummaryForAssociationsAffiliatedIdQuery request, CancellationToken cancellationToken)
        {
            var parameters = new
            {
                request.AssociationsAffiliatedId,
            };

            var paramNames = parameters.GetType().GetProperties().Select(s => "@" + s.Name);

            var result = _queryExecuter.Query<SummaryForAssociationsAffiliatedIdDto>(
                 "EXEC [dbo].[SP_GetSummaryForAssociationsAffiliatedId] " +
                string.Join(',', paramNames),
                parameters);

            return result;
        }

    }
}
