using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_Export_FamilyMembersByCouncilId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_Export_FamilyMembersByCouncilId]
	@CouncilId int
AS
BEGIN
	
	
SELECT
		p_rfm.IdentityNo ResponsibleFamilyMember_IdentityNo,
		frr.FamilyId,

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

		aawtc.Name AssociationsAffiliatedWithTheCouncilName
		
	FROM FamilyMembers fm WITH(NOLOCK)
	left join Families f WITH(NOLOCK) on f.Id = fm.FamilyId

	LEFT JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK) ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p_rfm WITH(NOLOCK) on p_rfm.Id = rfm.PersonalDataFormId 

	left JOIN PersonalDataForm p WITH(NOLOCK) on p.Id = fm.PersonalDataFormId 
	LEFT JOIN EducationalData ed WITH(NOLOCK) ON ed.Id = fm.EducationalDataId
	LEFT JOIN EducationalLevels el WITH(NOLOCK) ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd WITH(NOLOCK) ON hsd.Id = fm.HealthStatusDataId
	LEFT JOIN HealthStatuses hs WITH(NOLOCK) ON hs.Id = hsd.HealthStatusId

	LEFT JOIN Genders g WITH(NOLOCK) ON p.GenderId = g.Id
	LEFT JOIN Nationalities n WITH(NOLOCK) ON p.NationalityId = n.Id
	left JOIN FamilyRegistrationRequests frr WITH(NOLOCK) on frr.FamilyId = f.Id
	LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc WITH(NOLOCK) ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
	LEFT JOIN FamilyCategories fc WITH(NOLOCK) ON fc.Id = frr.FamilyCategoryId
	left join CouncilProjects cp WITH(NOLOCK) on cp.Id = frr.CouncilProjectId

	where @CouncilId = frr.AssociationsAffiliatedWithTheCouncilId
	and fm.IsDeleted = 0
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
