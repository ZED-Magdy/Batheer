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


namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetById
{
    public class GetByIdQuery : IRequest<TargetedSchedulingForProjectImplementation>
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, TargetedSchedulingForProjectImplementation>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<TargetedSchedulingForProjectImplementation> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .TargetedSchedulingForProjectImplementations
                .Include(t => t.AssociationAffiliatedProject)
                .ThenInclude(t => t.CouncilProject)
                .Include(t => t.TargetedSchedulingForProjectImplementationStatus)
                .Include(i => i.AssociationAffiliatedProject.AssociationAffiliatedProjectFamilyNeedDetails)
                .ThenInclude(i => i.FamilyNeedDetail)
                .Where(w => w.Id == request.Id)
                //.OrderBy(o => o.FullName)
                .ProjectTo<TargetedSchedulingForProjectImplementation>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
