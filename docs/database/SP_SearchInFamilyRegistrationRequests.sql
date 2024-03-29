USE [aspnet-BaSaleh]
GO
/****** Object:  StoredProcedure [dbo].[SP_SearchInFamilyRegistrationRequests]    Script Date: 19/06/21 02:17:15 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[SP_SearchInFamilyRegistrationRequests] (@fullName NVARCHAR(MAX)
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
		IIF(rfm.Id IS NULL, N'عائل الأسرة', N'فرد بالأسرة') FamilyMemberTypeName,
		uf.ObjectKey PersonalPhotoFileObjectKey,

		fc.Name FamilyCategoryName,
		'' FamilyNeedName
		
	FROM PersonalDataForm p
	LEFT JOIN FamilyMembers fm
		ON fm.PersonalDataFormId = p.Id
	LEFT JOIN ResponsibleFamilyMembers rfm
		ON rfm.PersonalDataFormId = p.Id
	LEFT JOIN Families f
		ON f.Id = fm.FamilyId
	LEFT JOIN AccommodationData ad
		ON ad.Id = f.AccommodationDataId
	LEFT JOIN AccommodationTypes at
		ON at.Id = ad.AccommodationTypeId
	LEFT JOIN ContactInformationData cd
		ON cd.Id = f.ContactInformationId
	LEFT JOIN MaritalStatusData msd
		ON msd.Id = rfm.MaritalStatusDataId
	LEFT JOIN MaritalStatuses ms
		ON ms.Id = msd.MaritalStatusId
	LEFT JOIN EducationalData ed
		ON ed.Id = fm.EducationalDataId
			OR rfm.EducationalDataId = ed.Id
	LEFT JOIN EducationalLevels el
		ON el.Id = ed.EducationalLevelId
	LEFT JOIN HealthStatusData hsd
		ON hsd.Id = fm.HealthStatusDataId
			OR hsd.Id = rfm.HealthStatusDataId
	LEFT JOIN HealthStatuses hs
		ON hs.Id = hsd.HealthStatusId
	LEFT JOIN OccupationData od
		ON od.Id = fm.EducationalDataId
			OR od.Id = rfm.OccupationDataId
	LEFT JOIN Occupations o
		ON o.Id = od.OccupationId
	LEFT JOIN MonthlyIncomeData mid
		ON mid.Id = f.MonthlyIncomeDataId
		LEFT JOIN MonthlyIncomes mi ON mi.Id = mid.MonthlyIncomeId
	LEFT JOIN FamilyRegistrationRequests frr
		ON frr.FamilyId = f.Id
	LEFT JOIN SupportingFamilyRequests sfr
		ON sfr.FamilyId = f.Id

		LEFT JOIN Genders g ON p.GenderId = g.Id
		LEFT JOIN Nationalities n ON p.NationalityId = n.Id
		LEFT JOIN AssociationsAffiliatedWithTheCouncils aawtc ON frr.AssociationsAffiliatedWithTheCouncilId = aawtc.Id
		LEFT JOIN UploadedFiles uf ON uf.Id = p.PersonalPhotoFileId

		LEFT JOIN FamilyCategories fc ON fc.Id = frr.FamilyCategoryId


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
END
