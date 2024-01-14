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

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByCreatedBy
{
    public class GetVisitingFamilyResultsByCreatedByQuery : IRequest<IEnumerable<VisitingFamilyResultDto>>
    {

        public GetVisitingFamilyResultsByCreatedByQuery()
        {
        }
    }

    public class GetVisitingFamilyResultsByCreatedByQueryHandler : IRequestHandler<GetVisitingFamilyResultsByCreatedByQuery, IEnumerable<VisitingFamilyResultDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;


        public GetVisitingFamilyResultsByCreatedByQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetVisitingFamilyResultsByCreatedByQuery> logger, ICurrentUserService currentUserService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<VisitingFamilyResultDto>> Handle(GetVisitingFamilyResultsByCreatedByQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.VisitingFamilyResults
                .Where(w => w.CreatedBy == _currentUserService.UserId)
                .Include(a => a.Family.ResponsibleFamilyMember.PersonalDataForm)
                .ProjectTo<VisitingFamilyResultDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
