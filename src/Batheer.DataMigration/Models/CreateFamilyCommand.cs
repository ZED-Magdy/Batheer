using System.Collections.Generic;

namespace Batheer.DataMigration.Models
{
    public class CreateFamilyCommand
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
}
