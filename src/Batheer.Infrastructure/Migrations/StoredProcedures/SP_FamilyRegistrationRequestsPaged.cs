using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_FamilyRegistrationRequestsPaged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"

ALTER PROCEDURE [dbo].[SP_FamilyRegistrationRequestsPaged]
(@fullName NVARCHAR(MAX)
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
, @CouncilObjectkey uniqueidentifier
, @FamilyCategoryId INT
, @FamilyNeedId INT
, @PageNumber int = 1
, @PageSize int = 20)
AS
BEGIN
	
	
SELECT 
		 ROW_NUMBER() OVER (ORDER BY f.Id) AS RowNumber,
		cp.Name 'CouncilProject',
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 1 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_01,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 2 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_02,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 3 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_03,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 4 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_04,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 5 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_05,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 6 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_06,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 7 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_07,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 8 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_08,
		(select 1 from FamilyNeedData WITH(NOLOCK) where FamilyNeedData.FamilyNeedId = 9 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_09,
		
		fc.Name FamilyCategoryName,
	 	P.FirstName ,
		P.FatherName,
		P.GrandFatherName,
		P.FamilyName,
		p.IdentityNo,
		p.DateOfBirth,
		p.PlaceOfBirth,
		g.Name GenderName,
		n.Name NationalityName,
		p.IdentityFileId,
		p.PersonalPhotoFileId,
		el.Name EducationalLevelName,
		hs.Name HealthStatusData_StatusName,
		hsd.Description HealthStatusData_Description,
		hsd.Others HealthStatusData_Others,
		o.Name	OccupationName,
		ms.Name MaritalStatusData_StatusName,
		msd.Others  MaritalStatusData_Others,

		cd.Email ContactInformationData_Email,
		cd.Mobile ContactInformationData_Mobile,
		cd.PhoneNumber ContactInformationData_PhoneNumber,
		cd.Facebook  ContactInformationData_Facebook,
		cd.Twitter  ContactInformationData_Twitter,
		cd.Instagram  ContactInformationData_Instagram,
		cd.Others  ContactInformationData_Others,

		rad.IsOutOfTabuk ResidencyAddressData_IsOutOfTabuk,
		rad.Province ResidencyAddressData_Province,
		rad.District ResidencyAddressData_District,
		rad.Street ResidencyAddressData_Street,
		rad.Others ResidencyAddressData_Others,
		rad.LocationOnTheMap ResidencyAddressData_LocationOnTheMap,


		AT.Name AccommodationData_TypeName,
		ad.Others AccommodationData_Others,
		
		mi.Name MonthlyIncomeName,

		ssd.AreYouABeneficiaryOfSocialSecurity SocialSecurityData_AreYouABeneficiaryOfSocialSecurity,
		ssd.Description SocialSecurityData_Description,
		

		f.Objectkey as FamilyObjectkey,
		f.Id as FamilyId,
		iif(sfr.id is null , 0, 1) HasSupportingFamilyRequest,

		aawtc.Name AssociationsAffiliatedWithTheCouncilName
		
	FROM Families f WITH(NOLOCK)
	LEFT JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK) ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p WITH(NOLOCK) on p.Id = rfm.PersonalDataFormId 
	LEFT JOIN FamilyMembers fm WITH(NOLOCK) ON fm.PersonalDataFormId = p.Id and fm.IsDeleted = 0
	LEFT JOIN AccommodationData ad WITH(NOLOCK) ON ad.Id = f.AccommodationDataId
	LEFT JOIN AccommodationTypes at WITH(NOLOCK) ON at.Id = ad.AccommodationTypeId
	LEFT JOIN ContactInformationData cd WITH(NOLOCK) ON cd.Id = f.ContactInformationId
	LEFT JOIN MaritalStatusData msd WITH(NOLOCK) ON msd.Id = rfm.MaritalStatusDataId
	LEFT JOIN MaritalStatuses ms WITH(NOLOCK) ON ms.Id = msd.MaritalStatusId
	LEFT JOIN EducationalData ed WITH(NOLOCK) ON ed.Id = rfm.EducationalDataId
	LEFT JOIN EducationalLevels el WITH(NOLOCK) ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd WITH(NOLOCK) ON hsd.Id = rfm.HealthStatusDataId
	LEFT JOIN HealthStatuses hs WITH(NOLOCK) ON hs.Id = hsd.HealthStatusId
	LEFT JOIN OccupationData od WITH(NOLOCK) ON od.Id = rfm.OccupationDataId
	LEFT JOIN Occupations o WITH(NOLOCK) ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid WITH(NOLOCK) ON mid.Id = f.MonthlyIncomeDataId
	LEFT JOIN MonthlyIncomes mi WITH(NOLOCK) ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr WITH(NOLOCK) ON frr.FamilyId = f.Id
	LEFT JOIN Genders g WITH(NOLOCK) ON p.GenderId = g.Id
	LEFT JOIN Nationalities n WITH(NOLOCK) ON p.NationalityId = n.Id
	LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
	--LEFT JOIN UploadedFiles uf ON uf.Id = p.PersonalPhotoFileId
	LEFT JOIN FamilyCategories fc WITH(NOLOCK) ON fc.Id = frr.FamilyCategoryId
	left join CouncilProjects cp WITH(NOLOCK) on cp.Id = frr.CouncilProjectId
	left join ResidencyAddressData rad WITH(NOLOCK) on rad.Id = f.ResidencyAddressDataId
	left join SocialSecurityData ssd WITH(NOLOCK) on ssd.Id = f.SocialSecurityDataId
	left JOIN dbo.SupportingFamilyRequests sfr WITH(NOLOCK) on sfr.FamilyId = f.id
WHERE 

(@fullName IS NULL
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
	AND (aawtc.objectkey = @CouncilObjectkey
	OR @CouncilObjectkey IS NULL)

	AND (@FamilyNeedId IS NULL OR EXISTS (SELECT 1 FROM FamilyNeedData fnd WITH(NOLOCK) WHERE fnd.FamilyNeedId = @FamilyNeedId AND fnd.FamilyRegistrationRequestId = frr.Id))
	AND (@FamilyCategoryId IS NULL OR @FamilyCategoryId = frr.FamilyCategoryId)
	and f.IsDeleted = 0
	ORDER by f.id

	OFFSET (@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY

	END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
