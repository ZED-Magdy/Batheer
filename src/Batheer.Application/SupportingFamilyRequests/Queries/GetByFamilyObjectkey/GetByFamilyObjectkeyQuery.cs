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

namespace Batheer.Application.SupportingFamilyRequests.Queries.GetByFamilyObjectkey
{
    public class GetByFamilyObjectkeyQuery : IRequest<SupportingFamilyRequestDto>
    {
        public Guid FamilyObjectkey { get; }

        public GetByFamilyObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
    }

    public class GetByFamilyObjectkeyQueryHandler : IRequestHandler<GetByFamilyObjectkeyQuery, SupportingFamilyRequestDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByFamilyObjectkeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByFamilyObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SupportingFamilyRequestDto> Handle(GetByFamilyObjectkeyQuery request, CancellationToken cancellationToken)
        {
            //var result1 = await _context.SupportingFamilyRequests
            //    .Where(w => w.Family.objectkey == request.FamilyObjectkey)
            //    .Include(a => a.BankDefaultData)
            //    .Include(a => a.FinanceData)
            //    .ThenInclude(i => i.FinanceType)
            //      .Include(i => i.FinanceData.ProducedFamilyProduct)
            //    .Include(a => a.LoanData)
            //    .ThenInclude(i => i.LoanType)
            //                    .Include(a => a.ProjectData)
            //    .ThenInclude(i => i.EstimatedProjectCost)
            //                    .Include(a => a.SupportingFamilyType)
            //                    .Include(a => a.WorkOnAProjectData)
            //   // .ProjectTo<SupportingFamilyRequestDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync();

            var result = await _context.SupportingFamilyRequests
                .Where(w => w.Family.objectkey == request.FamilyObjectkey)
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
