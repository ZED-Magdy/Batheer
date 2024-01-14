using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_Export_SupportingFamilyRequestsByCouncilId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER  PROCEDURE [dbo].[SP_Export_SupportingFamilyRequestsByCouncilId]
		@CouncilId int
AS
BEGIN

SELECT 
		p_rfm.IdentityNo ResponsibleFamilyMember_IdentityNo,
		sfr.FamilyId,
		sft.Name SupportingFamilyTypeName,

		bdd.IsThereABankDefault BankDefaultData_IsThereABankDefault,
		ft.Name FinanceData_FinanceTypeName,
		pfp.Name FinanceData_ProducedFamilyProductName,
		ld.DoYouHaveLoansOrOtherObligations LoanData_DoYouHaveLoansOrOtherObligations,
		lt.Name LoanData_LoanTypeName,
		ld.Others LoanData_Others,
		ld.Description LoanData_Description,

	 	epc.Name ProjectData_EstimatedProjectCostName,
		pd.Others ProjectData_Others,
		pd.AboutTheProject ProjectData_AboutTheProject,
		pd.WhatAreTheObstaclesFacingTheProject ProjectData_WhatAreTheObstaclesFacingTheProject,
		aawtc.Name AssociationsAffiliatedWithTheCouncilName
from SupportingFamilyRequests sfr WITH(NOLOCK)
inner join Families f WITH(NOLOCK) on f.id = sfr.FamilyId
inner join SupportingFamilyTypes sft WITH(NOLOCK) on sft.Id = sfr.SupportingFamilyTypeId

LEFT JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK) ON rfm.id = f.ResponsibleFamilyMemberId
left JOIN PersonalDataForm p_rfm WITH(NOLOCK) on p_rfm.Id = rfm.PersonalDataFormId 

left join BankDefaultData bdd WITH(NOLOCK) on bdd.Id = sfr.BankDefaultDataId
left join FinanceData fd WITH(NOLOCK) on fd.Id = sfr.FinanceDataId
left join FinanceTypes ft WITH(NOLOCK) on ft.Id = fd.FinanceTypeId
left join ProducedFamilyProducts pfp WITH(NOLOCK) on pfp.Id = fd.ProducedFamilyProductId

left join LoanData ld WITH(NOLOCK) on ld.Id = sfr.LoanDataId
left JOIN LoanTypes lt WITH(NOLOCK) on lt.Id = ld.LoanTypeId

left join ProjectData pd WITH(NOLOCK) on pd.Id = sfr.ProjectDataId
left join EstimatedProjectCosts epc WITH(NOLOCK) on epc.Id = pd.EstimatedProjectCostId
left join WorkOnAProjectData wopd WITH(NOLOCK) on wopd.Id = sfr.WorkOnAProjectDataId

left JOIN FamilyRegistrationRequests frr WITH(NOLOCK) on frr.FamilyId = f.Id
LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
where @CouncilId = frr.AssociationsAffiliatedWithTheCouncilId
	and f.IsDeleted = 0

END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

    }
}
