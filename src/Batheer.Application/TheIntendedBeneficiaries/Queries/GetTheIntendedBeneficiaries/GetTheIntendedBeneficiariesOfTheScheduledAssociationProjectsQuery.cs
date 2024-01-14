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


namespace Batheer.Application.TheIntendedBeneficiaries.Queries.GetTheIntendedBeneficiaries
{
    public class GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQuery : IRequest<IEnumerable<TheIntendedBeneficiariesOfTheScheduledAssociationProject>>
    {
    }

    public class GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQueryHandler : IRequestHandler<GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQuery, IEnumerable<TheIntendedBeneficiariesOfTheScheduledAssociationProject>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TheIntendedBeneficiariesOfTheScheduledAssociationProject>> Handle(GetTheIntendedBeneficiariesOfTheScheduledAssociationProjectsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(t => t.TargetedSchedulingForProjectImplementation)
                //.OrderBy(o => o.FullName)
                .ProjectTo<TheIntendedBeneficiariesOfTheScheduledAssociationProject>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
