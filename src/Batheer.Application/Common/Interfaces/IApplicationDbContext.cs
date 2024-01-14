using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.AuthenticationUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        IDbContextTransaction BeginTransaction();
        void RollbackTransaction();

        public DbSet<AccommodationData> AccommodationData { get; set; }
        public DbSet<BankDefaultData> BankDefaultData { get; set; }
        public DbSet<ContactInformationData> ContactInformationData { get; set; }
        public DbSet<EducationalData> EducationalData { get; set; }
        public DbSet<FinanceData> FinanceData { get; set; }
        public DbSet<HealthStatusData> HealthStatusData { get; set; }
        public DbSet<LoanData> LoanData { get; set; }
        public DbSet<MaritalStatusData> MaritalStatusData { get; set; }
        public DbSet<MonthlyIncomeData> MonthlyIncomeData { get; set; }
        public DbSet<OccupationData> OccupationData { get; set; }
        public DbSet<PersonalDataForm> PersonalDataForm { get; set; }
        public DbSet<ProjectData> ProjectData { get; set; }
        public DbSet<ResidencyAddressData> ResidencyAddressData { get; set; }
        public DbSet<SocialSecurityData> SocialSecurityData { get; set; }
        public DbSet<WorkOnAProjectData> WorkOnAProjectData { get; set; }
        public DbSet<AccommodationType> AccommodationTypes { get; set; }
        public DbSet<EducationalLevel> EducationalLevels { get; set; }
        public DbSet<EstimatedProjectCost> EstimatedProjectCosts { get; set; }
        public DbSet<FinanceType> FinanceTypes { get; set; }
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<MonthlyIncome> MonthlyIncomes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<ProducedFamilyProduct> ProducedFamilyProducts { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<AssociationAffiliatedProject> AssociationAffiliatedProjects { get; set; }
        public DbSet<AssociationAffiliatedProjectFamilyNeedDetail> AssociationAffiliatedProjectFamilyNeedDetails { get; set; }

        public DbSet<AssociationsAffiliatedWithTheCouncil> AssociationsAffiliatedWithTheCouncils { get; set; }
        public DbSet<AssociationsAffiliatedWithTheCouncilUser> AssociationsAffiliatedWithTheCouncilUsers { get; set; }
        public DbSet<CouncilProject> CouncilProjects { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachment> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachments { get; set; }
        public DbSet<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatuses { get; set; }
        public DbSet<TargetedSchedulingForProjectImplementation> TargetedSchedulingForProjectImplementations { get; set; }
        public DbSet<TargetedSchedulingForProjectImplementationStatus> TargetedSchedulingForProjectImplementationStatuses { get; set; }
        public DbSet<TheIntendedBeneficiariesOfTheScheduledAssociationProject> TheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }
        public DbSet<FamilyRegistrationRequest> FamilyRegistrationRequests { get; set; }
        public DbSet<SupportingFamilyRequest> SupportingFamilyRequests { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyCategory> FamilyCategories { get; set; }
        public DbSet<ResponsibleFamilyMember> ResponsibleFamilyMembers { get; set; }
        public DbSet<FamilyNeed> FamilyNeeds { get; set; }
        public DbSet<FamilyNeedDetail> FamilyNeedDetails { get; set; }
        public DbSet<FamilyNeedData> FamilyNeedData { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<SupportingFamilyType> SupportingFamilyTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<ExcludeIdentityNumber> ExcludeIdentityNumbers { get; set; }


        public DbSet<AssociationsAffiliatedWithTheCouncilInfo> AssociationsAffiliatedWithTheCouncilInfos { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        public DbSet<AssociationsAffiliatedWithTheCouncilInfoActivityType> AssociationsAffiliatedWithTheCouncilInfoActivityTypes { get; set; }


        public DbSet<City> Cities { get; set; }
        public DbSet<Town> Towns { get; set; }

        public DbSet<VisitingFamilyResult> VisitingFamilyResults { get; set; }

        public DbSet<VisitingFamilyMemberResult> VisitingFamilyMemberResults { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
