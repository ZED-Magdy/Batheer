using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.SearchInFamilies
{
    public class SearchInFamiliesDto
    {
        public string FullName { get; set; }
        public string IdentityNo { get; set; }
        public string GenderName { get; set; }
        public string NationalityName { get; set; }
        public string AccommodationTypeName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PhoneNumber { get; set; }
        public string MaritalStatusName { get; set; }
        public string EducationalLevelName { get; set; }
        public string HealthStatusName { get; set; }
        public string OccupationName { get; set; }
        public string MonthlyIncomeName { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
        public string HasSupportingFamilyRequest { get; set; }
        public string FamilyMemberTypeName { get; set; }
        public Guid PersonalPhotoFileObjectKey { get; set; }

        public string FamilyCategoryName { get; set; }
        public string FamilyNeedName { get; set; }

        public Guid ObjectKey { get; set; }
        public bool IsFamilyMember { get; set; }
    }
}
