using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_SearchInSupportingFamilyRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_SearchInSupportingFamilyRequests] (@fullName NVARCHAR(MAX)
, @identityNo NVARCHAR(50)
, @genderId INT
, @nationalityId INT
, @email NVARCHAR(MAX)
, @mobile NVARCHAR(50)
, @PhoneNumber NVARCHAR(50)
, @MaritalStatusId INT
, @EducationalLevelId INT
, @HealthStatusId INT
, @OccupationId INT
, @MonthlyIncomeId INT
, @AssociationsAffiliatedWithTheCouncilId INT
, @FamilyCategoryId INT

, @EstimatedProjectCostId INT
, @LoanTypeId INT
, @ProducedFamilyProductId INT
, @FinanceTypeId INT
, @AreYouFreeAndReadyToWorkOnAproject BIT
, @DoYouHaveLoansOrOtherObligations BIT
, @IsThereABankDefault BIT
)
AS
BEGIN


	SELECT
	 	CONCAT(P.FirstName ,' ' , P.FatherName, ' ', P.GrandFatherName, ' ', P.FamilyName) FullName,
		p.IdentityNo,
		g.Name GenderName,
		n.Name NationalityName,
		
		cd.Email,
		cd.Mobile,
		cd.PhoneNumber,
		ms.Name MaritalStatusName,
		el.Name EducationalLevelName,
		hs.Name HealthStatusName,
		o.Name	OccupationName,
		mi.Name MonthlyIncomeName,
		aawtc.Name AssociationsAffiliatedWithTheCouncilName,
		IIF(sfr.Id IS NULL, N'غير مسجل بتمكين الأسر', N'مسجل بتمكين الأسر') HasSupportingFamilyRequest,
		IIF(rfm.Id IS NULL, N'عائل الأسرة', N'فرد بالأسرة') FamilyMemberTypeName,
		uf.ObjectKey PersonalPhotoFileObjectKey,

		fc.Name FamilyCategoryName,
		'' FamilyNeedName
		
		,IIF(IsThereABankDefault = 0, N'لا',N'نعم') IsThereABankDefault
		,FinanceTypeId
		,ft.Name FinanceTypeName
		,ProducedFamilyProductId
		,pfp.Name ProducedFamilyProductName
		,IIF(DoYouHaveLoansOrOtherObligations = 0, N'لا',N'نعم')  DoYouHaveLoansOrOtherObligations
		,LoanTypeId
		,lt.Name LoanTypeName
		, EstimatedProjectCostId
		,epc.Name EstimatedProjectCostName
		,IIF(AreYouFreeAndReadyToWorkOnAproject = 0, N'لا',N'نعم') AreYouFreeAndReadyToWorkOnAproject
	FROM Families f WITH(NOLOCK)
	INNER JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK)
		ON rfm.Id = f.ResponsibleFamilyMemberId
	
	INNER JOIN PersonalDataForm p WITH(NOLOCK) ON p.Id = rfm.PersonalDataFormId
	INNER JOIN SupportingFamilyRequests sfr WITH(NOLOCK)
		ON sfr.FamilyId = f.Id

	LEFT JOIN ContactInformationData cd WITH(NOLOCK)
		ON cd.Id = f.ContactInformationId
	LEFT JOIN MaritalStatusData msd WITH(NOLOCK)
		ON msd.Id = rfm.MaritalStatusDataId
	LEFT JOIN MaritalStatuses ms WITH(NOLOCK)
		ON ms.Id = msd.MaritalStatusId
	LEFT JOIN EducationalData ed WITH(NOLOCK)
		ON ed.Id = rfm.EducationalDataId

	LEFT JOIN EducationalLevels el WITH(NOLOCK)
		ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd WITH(NOLOCK)
		ON hsd.Id = rfm.HealthStatusDataId
			
	LEFT JOIN HealthStatuses hs WITH(NOLOCK)
		ON hs.Id = hsd.HealthStatusId
	LEFT JOIN OccupationData od WITH(NOLOCK)
		ON od.Id = rfm.EducationalDataId
			
	LEFT JOIN Occupations o WITH(NOLOCK)
		ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid WITH(NOLOCK)
		ON mid.Id = f.MonthlyIncomeDataId
		LEFT JOIN MonthlyIncomes mi WITH(NOLOCK) ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr WITH(NOLOCK)
		ON frr.FamilyId = f.Id
	

		LEFT JOIN Genders g WITH(NOLOCK) ON p.GenderId = g.Id
		LEFT JOIN Nationalities n WITH(NOLOCK) ON p.NationalityId = n.Id
		LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
		LEFT JOIN UploadedFiles uf WITH(NOLOCK) ON uf.Id = p.PersonalPhotoFileId

		LEFT JOIN FamilyCategories fc WITH(NOLOCK) ON fc.Id = frr.FamilyCategoryId

		LEFT JOIN ProjectData pd WITH(NOLOCK) ON pd.Id =sfr.ProjectDataId
		LEFT JOIN LoanData ld WITH(NOLOCK) ON ld.id = sfr.LoanDataId
		LEFT JOIN LoanTypes lt WITH(NOLOCK) ON ld.LoanTypeId = lt.Id

		LEFT JOIN FinanceData fd WITH(NOLOCK) ON fd.id = sfr.FinanceDataId
		LEFT JOIN FinanceTypes ft WITH(NOLOCK) ON ft.id = fd.FinanceTypeId
		LEFT JOIN ProducedFamilyProducts pfp WITH(NOLOCK) ON pfp.id = fd.ProducedFamilyProductId
		LEFT JOIN WorkOnAProjectData woad WITH(NOLOCK) ON woad.id = sfr.WorkOnAProjectDataId
		LEFT  JOIN BankDefaultData bdd WITH(NOLOCK) ON bdd.id = sfr.BankDefaultDataId

		LEFT JOIN EstimatedProjectCosts epc WITH(NOLOCK) ON epc.id = pd.EstimatedProjectCostId
	WHERE (@fullName IS NULL
	OR p.FirstName LIKE @fullName
	OR p.FatherName LIKE @fullName
	OR p.GrandFatherName LIKE @fullName
	OR p.FamilyName LIKE @fullName)
	AND (p.IdentityNo LIKE @identityNo
	OR @identityNo IS NULL)
	AND (p.GenderId = @genderId
	OR @genderId IS NULL)
	AND (p.NationalityId = @nationalityId
	OR @nationalityId IS NULL)
	
	AND (cd.Email LIKE @email
	OR @email IS NULL)
	AND (cd.Mobile LIKE @mobile
	OR @mobile IS NULL)
	AND (cd.PhoneNumber LIKE @PhoneNumber
	OR @PhoneNumber IS NULL)
	AND (msd.MaritalStatusId = @MaritalStatusId
	OR @MaritalStatusId IS NULL)
	AND (ed.EducationalLevelId = @EducationalLevelId
	OR @EducationalLevelId IS NULL)
	AND (hsd.HealthStatusId = @HealthStatusId
	OR @HealthStatusId IS NULL)
	AND (od.OccupationId = @OccupationId
	OR @OccupationId IS NULL)
	AND (mid.MonthlyIncomeId = @MonthlyIncomeId
	OR @MonthlyIncomeId IS NULL)
	AND (frr.AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedWithTheCouncilId
	OR @AssociationsAffiliatedWithTheCouncilId IS NULL)
	AND (@FamilyCategoryId IS NULL OR @FamilyCategoryId = frr.FamilyCategoryId)

	AND (@EstimatedProjectCostId IS NULL OR @EstimatedProjectCostId = pd.EstimatedProjectCostId)
	AND (@LoanTypeId IS NULL OR @LoanTypeId = ld.LoanTypeId)
	AND(@ProducedFamilyProductId IS NULL OR @ProducedFamilyProductId = fd.ProducedFamilyProductId)
	AND (@FinanceTypeId IS NULL OR @FinanceTypeId = fd.FinanceTypeId)
	AND(@AreYouFreeAndReadyToWorkOnAproject IS NULL OR @AreYouFreeAndReadyToWorkOnAproject = woad.AreYouFreeAndReadyToWorkOnAproject)
	AND(@IsThereABankDefault IS NULL OR @IsThereABankDefault = bdd.IsThereABankDefault)

	AND (@DoYouHaveLoansOrOtherObligations IS NULL OR @DoYouHaveLoansOrOtherObligations = ld.DoYouHaveLoansOrOtherObligations)
	and f.IsDeleted =0
	
END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
