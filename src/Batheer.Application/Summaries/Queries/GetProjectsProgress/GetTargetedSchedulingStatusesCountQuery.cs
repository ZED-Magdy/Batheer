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


namespace Batheer.Application.Summaries.Queries.GetProjectsProgress
{
    public class GetProjectsProgressQuery : IRequest<List<ProgressDto>>
    {
        public int? CouncilId { get; }
        public GetProjectsProgressQuery(int? councilId)
        {
            CouncilId = councilId;
        }
    }
    public class GetProjectsProgressQueryHandler : IRequestHandler<GetProjectsProgressQuery, List<ProgressDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetProjectsProgressQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetProjectsProgressQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProgressDto>> Handle(GetProjectsProgressQuery request, CancellationToken cancellationToken)
        {

            Func<Domain.TargetedSchedulingForProjectImplementation, bool> _expression;

            if (request.CouncilId.HasValue)
                _expression = i => { return i.AssociationAffiliatedProject?.AssociationsAffiliatedWithTheCouncilId == request.CouncilId.Value; };
            else
                _expression = i => { return true; };

            var items = new List<ProgressDto>();



            _context.TargetedSchedulingForProjectImplementations
                .Include(i => i.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil)
                .Include(i => i.TheIntendedBeneficiariesOfTheScheduledAssociationProjects)
                .AsNoTracking()
                .Where(_expression)
                .OrderByDescending(o => o.Id)
                .Take(4)
                .ToList()
                .ForEach(f =>
                {
                    var i = new ProgressDto();

                    i.Title = f.AssociationAffiliatedProject.ProjectName;
                    i.Value = f.TheIntendedBeneficiariesOfTheScheduledAssociationProjects.Count();

                    var recieved = f.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                        .Where(c => string.IsNullOrEmpty(c.SmsSuccessReferenceNo) == false)
                        .Count();
                    var r = f.AssociationAffiliatedProject.CouncilProjectId;

                    i.TheCouncilName = f.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name;

                    if (i.Value != 0)
                        i.Progres = Convert.ToInt32((Convert.ToDouble(recieved) / Convert.ToDouble(i.Value)) * 100);

                    items.Add(i);
                });


            return items;
        }

    }
}
