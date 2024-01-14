using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.SearchInFamilies
{
    public abstract class BaseRequest
    {
        public string FullName { get; set; }
        public string IdentityNo { get; set; }

        public int? GenderId { get; set; }

        public int? NationalityId { get; set; }

        public int? AccommodationTypeId { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }

        public string PhoneNumber { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? EducationalLevelId { get; set; }

        public int? HealthStatusId { get; set; }

        public int? OccupationId { get; set; }

        public int? MonthlyIncomeId { get; set; }
        public int? FamilyCategoryId { get; set; }
        public int? FamilyNeedId { get; set; }

        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
        public bool? HasSupportingFamilyRequest { get; set; }
    }
}
