﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_Export_FamilyRegistrationRequestsByCouncilId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_Export_FamilyRegistrationRequestsByCouncilId]
	@CouncilId int
AS
BEGIN
	
SELECT
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
		


		aawtc.Name AssociationsAffiliatedWithTheCouncilName
		
	FROM Families f WITH(NOLOCK)
	LEFT JOIN ResponsibleFamilyMembers rfm WITH(NOLOCK) ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p WITH(NOLOCK) on p.Id = rfm.PersonalDataFormId 
	LEFT JOIN FamilyMembers fm WITH(NOLOCK) ON fm.PersonalDataFormId = p.Id and fm.IsDeleted = 1
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
