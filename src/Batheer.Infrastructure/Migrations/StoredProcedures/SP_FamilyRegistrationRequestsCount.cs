using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_FamilyRegistrationRequestsCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_FamilyRegistrationRequestsCount]
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
		count(1) as ItemsCount
		
	FROM Families f WITH(NOLOCK)
	LEFT JOIN ResponsibleFamilyMembers rfm ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p on p.Id = rfm.PersonalDataFormId 
	LEFT JOIN FamilyMembers fm ON fm.PersonalDataFormId = p.Id and fm.IsDeleted =0
	LEFT JOIN AccommodationData ad ON ad.Id = f.AccommodationDataId
	LEFT JOIN AccommodationTypes at ON at.Id = ad.AccommodationTypeId
	LEFT JOIN ContactInformationData cd ON cd.Id = f.ContactInformationId
	LEFT JOIN MaritalStatusData msd ON msd.Id = rfm.MaritalStatusDataId
	LEFT JOIN MaritalStatuses ms ON ms.Id = msd.MaritalStatusId
	LEFT JOIN EducationalData ed ON ed.Id = rfm.EducationalDataId
	LEFT JOIN EducationalLevels el ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd ON hsd.Id = rfm.HealthStatusDataId
	LEFT JOIN HealthStatuses hs ON hs.Id = hsd.HealthStatusId
	LEFT JOIN OccupationData od ON od.Id = rfm.OccupationDataId
	LEFT JOIN Occupations o ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid ON mid.Id = f.MonthlyIncomeDataId
	LEFT JOIN MonthlyIncomes mi ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr ON frr.FamilyId = f.Id
	LEFT JOIN Genders g ON p.GenderId = g.Id
	LEFT JOIN Nationalities n ON p.NationalityId = n.Id
	LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
	--LEFT JOIN UploadedFiles uf ON uf.Id = p.PersonalPhotoFileId
	LEFT JOIN FamilyCategories fc ON fc.Id = frr.FamilyCategoryId
	left join CouncilProjects cp on cp.Id = frr.CouncilProjectId
	left join ResidencyAddressData rad on rad.Id = f.ResidencyAddressDataId
	left join SocialSecurityData ssd on ssd.Id = f.SocialSecurityDataId
	left JOIN dbo.SupportingFamilyRequests sfr on sfr.FamilyId = f.id
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

	AND (@FamilyNeedId IS NULL OR EXISTS (SELECT 1 FROM FamilyNeedData fnd WHERE fnd.FamilyNeedId = @FamilyNeedId AND fnd.FamilyRegistrationRequestId = frr.Id))
	AND (@FamilyCategoryId IS NULL OR @FamilyCategoryId = frr.FamilyCategoryId)
		
	and f.IsDeleted = 0
	END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
