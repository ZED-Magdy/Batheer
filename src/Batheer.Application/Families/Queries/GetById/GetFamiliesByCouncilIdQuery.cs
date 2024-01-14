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

namespace Batheer.Application.Families.Queries.GetById
{
    /// <summary>
    /// جميع الطلبات الخاصة بالجمعية
    /// </summary>
    public class GetByIdQuery : IRequest<FamilyDetailsDto>
    {
        public GetByIdQuery(int familyId)
        {
            FamilyId = familyId;
        }
        public int FamilyId { get; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, FamilyDetailsDto>
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

        public async Task<FamilyDetailsDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Families
                .Include(t => t.AccommodationData)
                .Include(t => t.AccommodationData.AccommodationType)
                .Include(t => t.ContactInformationData)
                .Include(t => t.FamilyMembers)
                .Include(t => t.FamilyRegistrationRequest)
                .Include(t => t.FamilyRegistrationRequest.FamilyCategory)
                .Include(t => t.FamilyRegistrationRequest.FamilyNeedData)
                .Include(t => t.FamilyRegistrationRequest.FamilyNeedData)
                .ThenInclude(t => t.FamilyNeed)
                .Include(t => t.MonthlyIncomeData)
                .Include(t => t.MonthlyIncomeData.MonthlyIncome)
                .Include(t => t.ResidencyAddressData)
                .Include(t => t.ResponsibleFamilyMember)
                .Include(t => t.ResponsibleFamilyMember.EducationalData)
                .Include(t => t.ResponsibleFamilyMember.EducationalData.EducationalLevel)
                .Include(t => t.ResponsibleFamilyMember.HealthStatusData)
                .Include(t => t.ResponsibleFamilyMember.HealthStatusData.HealthStatus)
                .Include(t => t.ResponsibleFamilyMember.MaritalStatusData)
                .Include(t => t.ResponsibleFamilyMember.MaritalStatusData.MaritalStatus)
                .Include(t => t.ResponsibleFamilyMember.OccupationData)
                .Include(t => t.ResponsibleFamilyMember.OccupationData.Occupation)
                .Include(t => t.ResponsibleFamilyMember.PersonalDataForm)
                .Include(t => t.ResponsibleFamilyMember.PersonalDataForm.Gender)
                .Include(t => t.ResponsibleFamilyMember.PersonalDataForm.Nationality)
                .Include(t => t.SocialSecurityData)

                .Where(w => w.Id == request.FamilyId)
                .ProjectTo<FamilyDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
