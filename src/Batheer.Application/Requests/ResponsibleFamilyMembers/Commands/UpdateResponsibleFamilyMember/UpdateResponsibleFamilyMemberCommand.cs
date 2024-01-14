using AutoMapper;
using AutoMapper.QueryableExtensions;
using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models.RequestForms;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.ResponsibleFamilyMembers.Commands.UpdateResponsibleFamilyMember
{
    public class UpdateResponsibleFamilyMemberCommand : IRequest<int>
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


    }

    public class UpdateResponsibleFamilyMemberCommandHandler : IRequestHandler<UpdateResponsibleFamilyMemberCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UpdateResponsibleFamilyMemberCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<UpdateResponsibleFamilyMemberCommand> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(UpdateResponsibleFamilyMemberCommand request, CancellationToken cancellationToken)
        {

            var entity = new FamilyRegistrationRequest();
            entity.CouncilProjectId = request.CouncilProjectId;
            entity.AssociationsAffiliatedWithTheCouncilId = request.AssociationAffiliatedId;
            //entity = _mapper.Map<CreateRequestCommand, BaseRequest>(request);


            //if (request.PersonalDataForm.Id > 0)
            //{
            //    var personalDataForm = _context.PersonalDataForm.Find(request.PersonalDataForm.Id);
            //    entity.PersonalDataForm = personalDataForm;
            //}
            //else
            //{
            //    entity.PersonalDataForm = _mapper.Map<PersonalDataFormModel, PersonalDataForm>(request.PersonalDataForm);
            //}

            //entity.ContactInformation = _mapper.Map<ContactInformationDataModel, ContactInformationData>(request.ContactInformation);
            //entity.ResidencyAddressData = _mapper.Map<ResidencyAddressDataModel, ResidencyAddressData>(request.ResidencyAddressData);
            //entity.OccupationData = _mapper.Map<OccupationDataModel, OccupationData>(request.OccupationData);
            //entity.EducationalData = _mapper.Map<EducationalDataModel, EducationalData>(request.EducationalData);
            //entity.AccommodationData = _mapper.Map<AccommodationDataModel, AccommodationData>(request.AccommodationData);
            //entity.MaritalStatusData = _mapper.Map<MaritalStatusDataModel, MaritalStatusData>(request.MaritalStatusData);
            //entity.MonthlyIncomeData = _mapper.Map<MonthlyIncomeDataModel, MonthlyIncomeData>(request.MonthlyIncomeData);
            //entity.ProjectData = _mapper.Map<ProjectDataModel, ProjectData>(request.ProjectData);
            //entity.HealthStatusData = _mapper.Map<HealthStatusDataModel, HealthStatusData>(request.HealthStatusData);
            //entity.SocialSecurityData = _mapper.Map<SocialSecurityDataModel, SocialSecurityData>(request.SocialSecurityData);
            //entity.WorkOnAProjectData = _mapper.Map<WorkOnAProjectDataModel, WorkOnAProjectData>(request.WorkOnAProjectData);
            //entity.BankDefaultData = _mapper.Map<BankDefaultDataModel, BankDefaultData>(request.BankDefaultData);
            //entity.FinanceData = _mapper.Map<FinanceDataModel, FinanceData>(request.FinanceData);
            //entity.LoanData = _mapper.Map<LoanDataModel, LoanData>(request.LoanData);


            //entity.Title = request.Title;

            _context.FamilyRegistrationRequests.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }

}
