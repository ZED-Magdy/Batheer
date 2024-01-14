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
CREATE PROCEDURE SP_Export_FamilyRegistrationRequestsByCouncilId
	@CouncilId int
AS
BEGIN
	select N'äæÚ ÇáÏÚã_' + Name, * from FamilyNeeds
	
SELECT
		cp.Name 'CouncilProject',
		(select 1 from FamilyNeedData where FamilyNeedData.FamilyNeedId = 1 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_01,
		(select 1 from FamilyNeedData where FamilyNeedData.FamilyNeedId = 2 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_02,
		(select 1 from FamilyNeedData where FamilyNeedData.FamilyNeedId = 3 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_03,
		(select 1 from FamilyNeedData where FamilyNeedData.FamilyNeedId = 4 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_04,
		(select 1 from FamilyNeedData where FamilyNeedData.FamilyNeedId = 5 and FamilyNeedData.FamilyRegistrationRequestId = f.ResponsibleFamilyMemberId ) FamilyNeed_05,
		
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
	LEFT JOIN ResponsibleFamilyMembers rfm ON rfm.id = f.ResponsibleFamilyMemberId
	left JOIN PersonalDataForm p on p.Id = rfm.PersonalDataFormId 
	LEFT JOIN FamilyMembers fm ON fm.PersonalDataFormId = p.Id
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
	where @CouncilId = frr.AssociationsAffiliatedWithTheCouncilId
END
GO
