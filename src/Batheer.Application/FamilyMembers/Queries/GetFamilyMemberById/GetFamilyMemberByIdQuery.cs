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

namespace Batheer.Application.FamilyMembers.Queries.GetFamilyMemberById
{
    public class GetFamilyMemberByIdQuery : IRequest<FamilyMemberDto>
    {
        public int Id { get; }

        public GetFamilyMemberByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetFamilyMemberByIdQueryHandler : IRequestHandler<GetFamilyMemberByIdQuery, FamilyMemberDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetFamilyMemberByIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetFamilyMemberByIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FamilyMemberDto> Handle(GetFamilyMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.FamilyMembers
                .Where(w => w.Id == request.Id)
                .Include(a => a.EducationalData)
                .ThenInclude(i => i.EducationalLevel)
                .Include(a => a.HealthStatusData)
                .ThenInclude(i => i.HealthStatus)
                .Include(a => a.PersonalDataForm)
                .ThenInclude(i => i.Nationality)
                .ProjectTo<FamilyMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();




            var first = result.FirstOrDefault();


            var familyRegistrationRequest = _context.FamilyRegistrationRequests.Where(w => w.FamilyId == first.FamilyId).FirstOrDefault();
            first.FamilyRegistrationRequestId = familyRegistrationRequest.Id;

            return first;
        }

    }
}
