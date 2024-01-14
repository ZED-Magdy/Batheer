using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Reports.Queries.ExportSupportingFamilyRequests
{
    public class ExportSupportingFamilyRequestsDto
    {
        public string ResponsibleFamilyMember_IdentityNo { get; set; }
        public int FamilyId { get; set; }


        public string SupportingFamilyTypeName { get; set; }
        public bool BankDefaultData_IsThereABankDefault { get; set; }
        public string FinanceData_FinanceTypeName { get; set; }
        public string FinanceData_ProducedFamilyProductName { get; set; }

        public bool LoanData_DoYouHaveLoansOrOtherObligations { get; set; }
        public string LoanData_Others { get; set; }
        public string LoanData_LoanTypeName { get; set; }
        public string LoanData_Description { get; set; }
        public string ProjectData_EstimatedProjectCostName { get; set; }
        public string ProjectData_Others { get; set; }
        public string ProjectData_AboutTheProject { get; set; }
        public string ProjectData_WhatAreTheObstaclesFacingTheProject { get; set; }
        public bool WorkOnAProjectData_AreYouFreeAndReadyToWorkOnAproject { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
       
    }
}
