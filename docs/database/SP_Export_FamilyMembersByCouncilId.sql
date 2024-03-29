USE [aspnet-BaSaleh]
GO
/****** Object:  StoredProcedure [dbo].[SP_Export_FamilyMembersByCouncilId]    Script Date: 17/08/21 12:58:21 ص ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[SP_Export_FamilyMembersByCouncilId]
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
	left join Families f on f.Id = fm.FamilyId

	LEFT JOIN ResponsibleFamilyMembers rfm ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p_rfm on p_rfm.Id = rfm.PersonalDataFormId 

	left JOIN PersonalDataForm p on p.Id = fm.PersonalDataFormId 
	LEFT JOIN EducationalData ed ON ed.Id = fm.EducationalDataId
	LEFT JOIN EducationalLevels el ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd ON hsd.Id = fm.HealthStatusDataId
	LEFT JOIN HealthStatuses hs ON hs.Id = hsd.HealthStatusId

	LEFT JOIN Genders g ON p.GenderId = g.Id
	LEFT JOIN Nationalities n ON p.NationalityId = n.Id
	left JOIN FamilyRegistrationRequests frr on frr.FamilyId = f.Id
	LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
	LEFT JOIN FamilyCategories fc ON fc.Id = frr.FamilyCategoryId
	left join CouncilProjects cp on cp.Id = frr.CouncilProjectId

	where @CouncilId = frr.AssociationsAffiliatedWithTheCouncilId
END
