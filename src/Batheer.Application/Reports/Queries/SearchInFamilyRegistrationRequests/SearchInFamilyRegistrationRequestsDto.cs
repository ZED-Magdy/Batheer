using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.SearchInFamilyRegistrationRequests
{
    public class SearchInFamilyRegistrationRequestsDto
    {
        public string CouncilProject { get; set; }
        public string FamilyNeed_01 { get; set; }
        public string FamilyNeed_02 { get; set; }
        public string FamilyNeed_03 { get; set; }
        public string FamilyNeed_04 { get; set; }
        public string FamilyNeed_05 { get; set; }

        public string FamilyNeed_06 { get; set; }
        public string FamilyNeed_07 { get; set; }
        public string FamilyNeed_08 { get; set; }
        public string FamilyNeed_09 { get; set; }


        public string FamilyCategoryName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string IdentityNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string GenderName { get; set; }
        public string NationalityName { get; set; }

        public string IdentityFileId { get; set; }
        public string PersonalPhotoFileId { get; set; }
        public string EducationalLevelName { get; set; }
        public string HealthStatusData_StatusName { get; set; }
        public string HealthStatusData_Description { get; set; }
        public string HealthStatusData_Others { get; set; }
        public string OccupationName { get; set; }
        public string MaritalStatusData_StatusName { get; set; }
        public string MaritalStatusData_Others { get; set; }
        public string ContactInformationData_Email { get; set; }
        public string ContactInformationData_Mobile { get; set; }
        public string ContactInformationData_PhoneNumber { get; set; }
        public string ContactInformationData_Facebook { get; set; }
        public string ContactInformationData_Twitter { get; set; }
        public string ContactInformationData_Instagram { get; set; }
        public string ContactInformationData_Others { get; set; }
        public bool ResidencyAddressData_IsOutOfTabuk { get; set; }
        public string ResidencyAddressData_Province { get; set; }
        public string ResidencyAddressData_District { get; set; }
        public string ResidencyAddressData_Street { get; set; }
        public string ResidencyAddressData_Others { get; set; }
        public string ResidencyAddressData_LocationOnTheMap { get; set; }
        public string AccommodationData_TypeName { get; set; }
        public string AccommodationData_Others { get; set; }
        public string MonthlyIncomeName { get; set; }
        public bool SocialSecurityData_AreYouABeneficiaryOfSocialSecurity { get; set; }
        public string SocialSecurityData_Description { get; set; }

        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
    }
}
