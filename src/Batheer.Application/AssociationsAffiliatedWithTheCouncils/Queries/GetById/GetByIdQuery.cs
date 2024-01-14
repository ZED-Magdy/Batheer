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

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncils.Queries.GetById
{
    public class GetByIdQuery : IRequest<AssociationsAffiliatedWithTheCouncil>
    {
        public GetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, AssociationsAffiliatedWithTheCouncil>
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

        public async Task<AssociationsAffiliatedWithTheCouncil> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .AssociationsAffiliatedWithTheCouncils
                .Where(w=> w.Id == request.Id)
                .OrderBy(o => o.Name)
                .ProjectTo<AssociationsAffiliatedWithTheCouncil>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
