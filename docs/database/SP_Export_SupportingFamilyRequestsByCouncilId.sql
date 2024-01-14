-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_Export_SupportingFamilyRequestsByCouncilId
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
from SupportingFamilyRequests sfr
inner join Families f on f.id = sfr.FamilyId
inner join SupportingFamilyTypes sft on sft.Id = sfr.SupportingFamilyTypeId

	LEFT JOIN ResponsibleFamilyMembers rfm ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p_rfm on p_rfm.Id = rfm.PersonalDataFormId 

	left join BankDefaultData bdd on bdd.Id = sfr.BankDefaultDataId
	left join FinanceData fd on fd.Id = sfr.FinanceDataId
	left join FinanceTypes ft on ft.Id = fd.FinanceTypeId
	left join ProducedFamilyProducts pfp on pfp.Id = fd.ProducedFamilyProductId

	left join LoanData ld on ld.Id = sfr.LoanDataId
	left JOIN LoanTypes lt on lt.Id = ld.LoanTypeId

	left join ProjectData pd on pd.Id = sfr.ProjectDataId
	left join EstimatedProjectCosts epc on epc.Id = pd.EstimatedProjectCostId
	left join WorkOnAProjectData wopd on wopd.Id = sfr.WorkOnAProjectDataId

	left JOIN FamilyRegistrationRequests frr on frr.FamilyId = f.Id
	LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
	where @CouncilId = frr.AssociationsAffiliatedWithTheCouncilId

END
GO
