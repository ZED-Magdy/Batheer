using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByUser
{
    public class GetVisitingFamilyResultsByUserQuery : IRequest<VisitingFamilyResultDto>
    {
        public Guid FamilyObjectkey { get; }


        public GetVisitingFamilyResultsByUserQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetVisitingFamilyResultsByUserQueryHandler : IRequestHandler<GetVisitingFamilyResultsByUserQuery, VisitingFamilyResultDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;



        public GetVisitingFamilyResultsByUserQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyResultsByUserQuery> logger, ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<VisitingFamilyResultDto> Handle(GetVisitingFamilyResultsByUserQuery request, CancellationToken cancellationToken)
        {

                var result = await _context.VisitingFamilyResults
                .Where(w => w.Family.objectkey == request.FamilyObjectkey)
                .Where(w=> w.CreatedBy == _currentUserService.UserId)
                .Where(w=> w.Created.AddDays(30) >= _dateTime.Now)
                .Include(a => a.Family.ResponsibleFamilyMember.PersonalDataForm)
                .ProjectTo<VisitingFamilyResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result.FirstOrDefault();
        }

    }
}
