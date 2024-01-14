using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.ExportFamilyMembers
{
    public class ExportFamilyMembersDto
    {
        public string ResponsibleFamilyMember_IdentityNo { get; set; }
        public int FamilyId { get; set; }
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
       
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
    }
}
