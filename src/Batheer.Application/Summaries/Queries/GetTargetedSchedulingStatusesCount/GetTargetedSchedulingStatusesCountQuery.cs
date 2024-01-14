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


namespace Batheer.Application.Summaries.Queries.GetTargetedSchedulingStatusesCount
{
    public class GetTargetedSchedulingStatusesCountQuery : IRequest<List<RequestsCountDto>>
    {
        public int? CouncilId { get; }
        public GetTargetedSchedulingStatusesCountQuery(int? councilId)
        {
            CouncilId = councilId;
        }
    }
    public class GetTargetedSchedulingStatusesCountQueryHandler : IRequestHandler<GetTargetedSchedulingStatusesCountQuery, List<RequestsCountDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTargetedSchedulingStatusesCountQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTargetedSchedulingStatusesCountQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RequestsCountDto>> Handle(GetTargetedSchedulingStatusesCountQuery request, CancellationToken cancellationToken)
        {

            Func<Domain.TargetedSchedulingForProjectImplementation, bool> _expression;

            if (request.CouncilId.HasValue)
                _expression = i => { return i.AssociationAffiliatedProject?.AssociationsAffiliatedWithTheCouncilId == request.CouncilId.Value; };
            else
                _expression = i => { return true; };

            var items = new List<RequestsCountDto>();

            items.Add(new RequestsCountDto()
            {
                Key = 1,
                Value = _context.TargetedSchedulingForProjectImplementations
                .Where(w => w.TargetedSchedulingForProjectImplementationStatusId == 1)
                .Where(_expression).Count()
            });



            items.Add(new RequestsCountDto()
            {
                Key = 2,
                Value = _context.TargetedSchedulingForProjectImplementations
                .Where(w => w.TargetedSchedulingForProjectImplementationStatusId == 2)
                .Where(_expression).Count()
            });


            items.Add(new RequestsCountDto()
            {
                Key = 3,
                Value = _context.TargetedSchedulingForProjectImplementations
                .Where(w => w.TargetedSchedulingForProjectImplementationStatusId == 3)
                .Where(_expression).Count()
            });

            return items;
        }

    }
}
