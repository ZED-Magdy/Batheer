using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyMemberResultsByUser
{
    public class GetVisitingFamilyMemberResultsByUserQuery : IRequest<VisitingFamilyMemberResultDto>
    {
        public Guid FamilyMemberObjectkey { get; }


        public GetVisitingFamilyMemberResultsByUserQuery(Guid familyMemberObjectkey)
        {
            FamilyMemberObjectkey = familyMemberObjectkey;
        }
    }

    public class GetVisitingFamilyMemberResultsByUserQueryHandler : IRequestHandler<GetVisitingFamilyMemberResultsByUserQuery, VisitingFamilyMemberResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;



        public GetVisitingFamilyMemberResultsByUserQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyMemberResultsByUserQuery> logger, ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<VisitingFamilyMemberResultDto> Handle(GetVisitingFamilyMemberResultsByUserQuery request, CancellationToken cancellationToken)
        {

                var result = await _context.VisitingFamilyMemberResults
                .Where(w => w.FamilyMember.objectkey == request.FamilyMemberObjectkey)
                .Where(w=> w.CreatedBy == _currentUserService.UserId)
                .Where(w=> w.Created.AddDays(30) >= _dateTime.Now)
                .Include(a => a.FamilyMember)
                .ProjectTo<VisitingFamilyMemberResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
