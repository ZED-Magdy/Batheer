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

namespace Batheer.Application.AssociationAffiliatedProjects.Queries.GetById
{
    public class GetByIdQuery : IRequest<AssociationAffiliatedProject>
    {
        public int AssociationsAffiliatedId { get; }

        public GetByIdQuery(int associationsAffiliatedId)
        {
            AssociationsAffiliatedId = associationsAffiliatedId;
        }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, AssociationAffiliatedProject>
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

        public async Task<AssociationAffiliatedProject> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.AssociationAffiliatedProjects
                .Where(w=> w.Id == request.AssociationsAffiliatedId)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .Include(i=> i.AssociationAffiliatedProjectFamilyNeedDetails)
                .ThenInclude(i=> i.FamilyNeedDetail)
                .ProjectTo<AssociationAffiliatedProject>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
