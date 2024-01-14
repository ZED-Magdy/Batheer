using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_SearchInFamilies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_SearchInFamilies] (@fullName NVARCHAR(MAX)
, @identityNo NVARCHAR(50)
, @genderId INT
, @nationalityId INT
, @AccommodationTypeId INT
, @email NVARCHAR(MAX)
, @mobile NVARCHAR(50)
, @PhoneNumber NVARCHAR(50)
, @MaritalStatusId INT
, @EducationalLevelId INT
, @HealthStatusId INT
, @OccupationId INT
, @MonthlyIncomeId INT
, @AssociationsAffiliatedWithTheCouncilId INT
, @HasSupportingFamilyRequest BIT
, @FamilyCategoryId INT
, @FamilyNeedId INT)
AS
BEGIN


	SELECT
	 	CONCAT(P.FirstName ,' ' , P.FatherName, ' ', P.GrandFatherName, ' ', P.FamilyName) FullName,
		p.IdentityNo,
		g.Name GenderName,
		n.Name NationalityName,
		AT.Name AccommodationTypeName,
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
		 N'عائل الأسرة' FamilyMemberTypeName,
		uf.ObjectKey PersonalPhotoFileObjectKey,

		fc.Name FamilyCategoryName,
		'' FamilyNeedName,
		f.objectkey,
		0 IsFamilyMember
	FROM Families f WITH(NOLOCK)
	LEFT JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK) ON rfm.id = f.ResponsibleFamilyMemberId
	LEFT JOIN dbo.PersonalDataForm p WITH(NOLOCK) ON p.Id = rfm.PersonalDataFormId

	LEFT JOIN AccommodationData ad WITH(NOLOCK)
		ON ad.Id = f.AccommodationDataId
	LEFT JOIN AccommodationTypes at WITH(NOLOCK)
		ON at.Id = ad.AccommodationTypeId
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
		ON od.Id = rfm.OccupationDataId
	LEFT JOIN Occupations o WITH(NOLOCK)
		ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid WITH(NOLOCK)
		ON mid.Id = f.MonthlyIncomeDataId
		LEFT JOIN MonthlyIncomes mi ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr WITH(NOLOCK)
		ON frr.FamilyId = f.Id
	LEFT JOIN SupportingFamilyRequests sfr WITH(NOLOCK)
		ON sfr.FamilyId = f.Id

		LEFT JOIN Genders g WITH(NOLOCK) ON p.GenderId = g.Id
		LEFT JOIN Nationalities n WITH(NOLOCK) ON p.NationalityId = n.Id
		LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
		LEFT JOIN UploadedFiles uf WITH(NOLOCK) ON uf.Id = p.PersonalPhotoFileId

		LEFT JOIN FamilyCategories fc WITH(NOLOCK) ON fc.Id = frr.FamilyCategoryId


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
	AND (ad.AccommodationTypeId = @AccommodationTypeId
	OR @AccommodationTypeId IS NULL)
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
	AND (@HasSupportingFamilyRequest IS NULL
	OR (@HasSupportingFamilyRequest = 0
	AND sfr.Id IS NULL)
	OR (@HasSupportingFamilyRequest = 1
	AND sfr.Id IS NOT NULL))
	AND (@FamilyNeedId IS NULL OR EXISTS (SELECT 1 FROM FamilyNeedData fnd WHERE fnd.FamilyNeedId = @FamilyNeedId AND fnd.FamilyRegistrationRequestId = frr.Id))
	AND (@FamilyCategoryId IS NULL OR @FamilyCategoryId = frr.FamilyCategoryId)
	and f.IsDeleted = 0
	

	UNION
	

	SELECT
	 	CONCAT(P.FirstName ,' ' , P.FatherName, ' ', P.GrandFatherName, ' ', P.FamilyName) FullName,
		p.IdentityNo,
		g.Name GenderName,
		n.Name NationalityName,
		AT.Name AccommodationTypeName,
		cd.Email,
		cd.Mobile,
		cd.PhoneNumber,
		'ms.Name' MaritalStatusName,
		el.Name EducationalLevelName,
		hs.Name HealthStatusName,
		'o.Name'	OccupationName,
		mi.Name MonthlyIncomeName,
		aawtc.Name AssociationsAffiliatedWithTheCouncilName,
		IIF(sfr.Id IS NULL, N'غير مسجل بتمكين الأسر', N'مسجل بتمكين الأسر') HasSupportingFamilyRequest,
		 N'فرد بالأسرة' FamilyMemberTypeName,
		uf.ObjectKey PersonalPhotoFileObjectKey,

		fc.Name FamilyCategoryName,
		'' FamilyNeedName,
		fm.objectkey,
		1 IsFamilyMember
		
	FROM Families f WITH(NOLOCK)
	LEFT JOIN FamilyMembers fm WITH(NOLOCK) ON fm.familyId = f.Id and fm.IsDeleted =0
	LEFT JOIN dbo.PersonalDataForm p WITH(NOLOCK) ON p.id = fm.PersonalDataFormId


	LEFT JOIN AccommodationData ad WITH(NOLOCK)
		ON ad.Id = f.AccommodationDataId
	LEFT JOIN AccommodationTypes at WITH(NOLOCK)
		ON at.Id = ad.AccommodationTypeId
	LEFT JOIN ContactInformationData cd WITH(NOLOCK)
		ON cd.Id = f.ContactInformationId
	--LEFT JOIN MaritalStatusData msd
	--	ON msd.Id = rfm.MaritalStatusDataId
	--LEFT JOIN MaritalStatuses ms
	--	ON ms.Id = msd.MaritalStatusId
	LEFT JOIN EducationalData ed WITH(NOLOCK)
		ON ed.Id = fm.EducationalDataId
	LEFT JOIN EducationalLevels el WITH(NOLOCK)
		ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd WITH(NOLOCK)
		ON hsd.Id = fm.HealthStatusDataId
			
	LEFT JOIN HealthStatuses hs WITH(NOLOCK)
		ON hs.Id = hsd.HealthStatusId
	--LEFT JOIN OccupationData od
	--	ON od.Id = fm.EducationalDataId
	--		OR od.Id = rfm.OccupationDataId
	--LEFT JOIN Occupations o
	--	ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid WITH(NOLOCK)
		ON mid.Id = f.MonthlyIncomeDataId
		LEFT JOIN MonthlyIncomes mi WITH(NOLOCK) ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr WITH(NOLOCK)
		ON frr.FamilyId = f.Id
	LEFT JOIN SupportingFamilyRequests sfr WITH(NOLOCK)
		ON sfr.FamilyId = f.Id

		LEFT JOIN Genders g WITH(NOLOCK) ON p.GenderId = g.Id
		LEFT JOIN Nationalities n WITH(NOLOCK) ON p.NationalityId = n.Id
		LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
		LEFT JOIN UploadedFiles uf WITH(NOLOCK) ON uf.Id = p.PersonalPhotoFileId

		LEFT JOIN FamilyCategories fc WITH(NOLOCK) ON fc.Id = frr.FamilyCategoryId


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
	AND (ad.AccommodationTypeId = @AccommodationTypeId
	OR @AccommodationTypeId IS NULL)
	AND (cd.Email LIKE @email
	OR @email IS NULL)
	AND (cd.Mobile LIKE @mobile
	OR @mobile IS NULL)
	AND (cd.PhoneNumber LIKE @PhoneNumber
	OR @PhoneNumber IS NULL)
	--AND (msd.MaritalStatusId = @MaritalStatusId
	--OR @MaritalStatusId IS NULL)
	AND (ed.EducationalLevelId = @EducationalLevelId
	OR @EducationalLevelId IS NULL)
	AND (hsd.HealthStatusId = @HealthStatusId
	OR @HealthStatusId IS NULL)
	--AND (od.OccupationId = @OccupationId
	--OR @OccupationId IS NULL)
	AND (mid.MonthlyIncomeId = @MonthlyIncomeId
	OR @MonthlyIncomeId IS NULL)
	AND (frr.AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedWithTheCouncilId
	OR @AssociationsAffiliatedWithTheCouncilId IS NULL)
	AND (@HasSupportingFamilyRequest IS NULL
	OR (@HasSupportingFamilyRequest = 0
	AND sfr.Id IS NULL)
	OR (@HasSupportingFamilyRequest = 1
	AND sfr.Id IS NOT NULL))
	AND (@FamilyNeedId IS NULL OR EXISTS (SELECT 1 FROM FamilyNeedData fnd  WHERE fnd.FamilyNeedId = @FamilyNeedId AND fnd.FamilyRegistrationRequestId = frr.Id))
	AND (@FamilyCategoryId IS NULL OR @FamilyCategoryId = frr.FamilyCategoryId)
	and f.IsDeleted = 0
END
";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
