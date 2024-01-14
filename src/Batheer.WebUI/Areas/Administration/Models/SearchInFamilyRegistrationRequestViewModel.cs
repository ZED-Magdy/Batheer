using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.Areas.Administration.Models
{
    public class SearchInFamilyRegistrationRequestViewModel
    {
        public string Name { get; set; }
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

        public int? FinanceTypeId { get; set; }


        public int? LoanTypeId { get; set; }
        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
    }
}
