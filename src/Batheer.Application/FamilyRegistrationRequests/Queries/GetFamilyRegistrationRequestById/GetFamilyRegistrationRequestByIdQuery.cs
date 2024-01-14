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
namespace Batheer.Application.FamilyRegistrationRequests.Queries.GetFamilyRegistrationRequestById
{
    public class GetFamilyRegistrationRequestByIdQuery : IRequest<FamilyRegistrationRequest>
    {
        public int Id { get; }

        public GetFamilyRegistrationRequestByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetFamilyRegistrationRequestByIdQueryHandler : IRequestHandler<GetFamilyRegistrationRequestByIdQuery, FamilyRegistrationRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyRegistrationRequestByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyRegistrationRequestByIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FamilyRegistrationRequest> Handle(GetFamilyRegistrationRequestByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FamilyRegistrationRequests
                .Where(w => w.Id == request.Id)
                .Include(a => a.AssociationsAffiliatedWithTheCouncil)
                .Include(a => a.CouncilProject)
                .ProjectTo<FamilyRegistrationRequest>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
