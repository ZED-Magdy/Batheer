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

namespace Batheer.Application.Families.Queries.GetByObjectkey
{
    /// <summary>
    /// جميع الطلبات الخاصة بالجمعية
    /// </summary>
    public class GetByObjectkeyQuery : IRequest<FamilyDetailsDto>
    {
        public GetByObjectkeyQuery(Guid familyObjectkey)
        {
            FamilyObjectkey = familyObjectkey;
        }
        public Guid FamilyObjectkey { get; }
    }

    public class GetByObjectkeyQueryHandler : IRequestHandler<GetByObjectkeyQuery, FamilyDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetByObjectkeyQueryHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetByObjectkeyQuery> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FamilyDetailsDto> Handle(GetByObjectkeyQuery request, CancellationToken cancellationToken)
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

                .Where(w => w.objectkey == request.FamilyObjectkey)
                .ProjectTo<FamilyDetailsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result.FirstOrDefault();
        }

    }
}
