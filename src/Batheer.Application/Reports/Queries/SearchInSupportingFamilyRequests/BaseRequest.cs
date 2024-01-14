using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.SearchInSupportingFamilyRequests
{
    public abstract class BaseRequest
    {
        public string FullName { get; set; }
        public string IdentityNo { get; set; }

        public int? GenderId { get; set; }
        public int? EstimatedProjectCostId { get; set; }
        public int? LoanTypeId { get; set; }
        public int? ProducedFamilyProductId { get; set; }
        public int? FinanceTypeId { get; set; }

        public int? NationalityId { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }

        public string PhoneNumber { get; set; }

        public int? MaritalStatusId { get; set; }

        public int? EducationalLevelId { get; set; }

        public int? HealthStatusId { get; set; }

        public int? OccupationId { get; set; }

        public int? MonthlyIncomeId { get; set; }
        public int? FamilyCategoryId { get; set; }

        public int? AssociationsAffiliatedWithTheCouncilId { get; set; }
        public bool? AreYouFreeAndReadyToWorkOnAproject { get; set; }
        public bool? DoYouHaveLoansOrOtherObligations { get; set; }
        public bool? IsThereABankDefault { get; set; }
    }
}
