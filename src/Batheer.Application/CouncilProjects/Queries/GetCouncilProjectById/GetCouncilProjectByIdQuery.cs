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

namespace Batheer.Application.CouncilProjects.Queries.GetCouncilProjectById
{
    public class GetCouncilProjectByIdQuery : IRequest<CouncilProject>
    {
        public int Id { get;}

        public GetCouncilProjectByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetCouncilProjectByIdQueryHandler : IRequestHandler<GetCouncilProjectByIdQuery, CouncilProject>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCouncilProjectByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetCouncilProjectByIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CouncilProject> Handle(GetCouncilProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .CouncilProjects
                .Where(w=> w.Id == request.Id)
                .ProjectTo<CouncilProject>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
