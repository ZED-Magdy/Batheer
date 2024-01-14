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

namespace Batheer.Application.SupportingFamilyRequests.Queries.GetByFamilyId
{
    public class GetByFamilyIdQuery : IRequest<SupportingFamilyRequestDto>
    {
        public int FamilyId { get; }

        public GetByFamilyIdQuery(int familyId)
        {
            FamilyId = familyId;
        }
    }

    public class GetByFamilyIdQueryHandler : IRequestHandler<GetByFamilyIdQuery, SupportingFamilyRequestDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByFamilyIdQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByFamilyIdQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SupportingFamilyRequestDto> Handle(GetByFamilyIdQuery request, CancellationToken cancellationToken)
        {
            var result1 = await _context.SupportingFamilyRequests
                .Where(w => w.FamilyId == request.FamilyId)
                .Include(a => a.BankDefaultData)
                .Include(a => a.FinanceData)
                .ThenInclude(i => i.FinanceType)
                  .Include(i => i.FinanceData.ProducedFamilyProduct)
                .Include(a => a.LoanData)
                .ThenInclude(i => i.LoanType)
                                .Include(a => a.ProjectData)
                .ThenInclude(i => i.EstimatedProjectCost)
                                .Include(a => a.SupportingFamilyType)
                                .Include(a => a.WorkOnAProjectData)
               // .ProjectTo<SupportingFamilyRequestDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var result = await _context.SupportingFamilyRequests
                .Where(w => w.FamilyId == request.FamilyId)
                .Include(a => a.BankDefaultData)
                .Include(a => a.FinanceData)
                .ThenInclude(i => i.FinanceType)
                .Include(i=> i.FinanceData.ProducedFamilyProduct)
                .Include(a => a.LoanData)
                .ThenInclude(i => i.LoanType)
                                .Include(a => a.ProjectData)
                .ThenInclude(i => i.EstimatedProjectCost)
                                .Include(a => a.SupportingFamilyType)
                                .Include(a => a.WorkOnAProjectData)
                .ProjectTo<SupportingFamilyRequestDto>(_mapper.ConfigurationProvider)
                .ToListAsync();


            return result.FirstOrDefault();

        }

    }
}
