using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaSaleh.Application.Common.Interfaces;
using BaSaleh.Application.Common.Models.RequestForms;
using BaSaleh.Domain.AssociationAffiliatedProjects;
using BaSaleh.Domain.AssociationAffiliatedProjects.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BaSaleh.Application.Requests.BaseRequests.Commands.CreateRequest
{
    public class CreateRequestCommand : IRequest<int>
    {
        public int AssociationAffiliatedId { get; set; }
        public int CouncilProjectId { get; set; }

        public virtual PersonalDataFormModel PersonalDataForm { get; set; }
        public virtual ContactInformationDataModel ContactInformation { get; set; }
        public virtual ResidencyAddressDataModel ResidencyAddressData { get; set; }
        public virtual EducationalDataModel EducationalData { get; set; }

        public virtual HealthStatusDataModel HealthStatusData { get; set; }
        public virtual MaritalStatusDataModel MaritalStatusData { get; set; }

        public virtual OccupationDataModel OccupationData { get; set; }
        public virtual AccommodationDataModel AccommodationData { get; set; }

        public virtual BankDefaultDataModel BankDefaultData { get; set; }
        public virtual FinanceDataModel FinanceData { get; set; }
        public virtual LoanDataModel LoanData { get; set; }
        public virtual MonthlyIncomeDataModel MonthlyIncomeData { get; set; }
        public virtual ProjectDataModel ProjectData { get; set; }
        public virtual SocialSecurityDataModel SocialSecurityData { get; set; }
        public virtual WorkOnAProjectDataModel WorkOnAProjectData { get; set; }
        public virtual FamilyCategoryDataModel FamilyCategoryData { get; set; }
        public virtual List<FamilyNeedDataModel> FamilyNeedData { get; set; }


    }

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreateRequestCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CreateRequestCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = new Family();


            entity.FamilyRegistrationRequest = new FamilyRegistrationRequest()
            {
                CouncilProjectId = request.CouncilProjectId,
                AssociationsAffiliatedWithTheCouncilId = request.AssociationAffiliatedId,
                FamilyCategoryId = request.FamilyCategoryData.FamilyCategoryId,
                //request.FamilyNeedData.Select(s=> new Domain.AssociationAffiliatedProjects.Lookups.FamilyNeed() {  })
            };

            entity.ContactInformationData = _mapper.Map<ContactInformationDataModel, ContactInformationData>(request.ContactInformation);
            entity.ResidencyAddressData = _mapper.Map<ResidencyAddressDataModel, ResidencyAddressData>(request.ResidencyAddressData);
            entity.AccommodationData = _mapper.Map<AccommodationDataModel, AccommodationData>(request.AccommodationData);
            entity.MonthlyIncomeData = _mapper.Map<MonthlyIncomeDataModel, MonthlyIncomeData>(request.MonthlyIncomeData);
            entity.SocialSecurityData = _mapper.Map<SocialSecurityDataModel, SocialSecurityData>(request.SocialSecurityData);


            entity.ResponsibleFamilyMember = new ResponsibleFamilyMember();
            entity.ResponsibleFamilyMember.PersonalDataForm = _mapper.Map<PersonalDataFormModel, PersonalDataForm>(request.PersonalDataForm);
            entity.ResponsibleFamilyMember.OccupationData = _mapper.Map<OccupationDataModel, OccupationData>(request.OccupationData);
            entity.ResponsibleFamilyMember.EducationalData = _mapper.Map<EducationalDataModel, EducationalData>(request.EducationalData);
            entity.ResponsibleFamilyMember.MaritalStatusData = _mapper.Map<MaritalStatusDataModel, MaritalStatusData>(request.MaritalStatusData);
            entity.ResponsibleFamilyMember.HealthStatusData = _mapper.Map<HealthStatusDataModel, HealthStatusData>(request.HealthStatusData);



            _context.Families.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
