/****** Script for SelectTopNRows command from SSMS  ******/
SELECT MonthlyIncomeData_MonthlyIncomeId, EducationalData_EducationalLevelId,PersonalDataForm_PlaceOfBirth,PersonalDataForm_IdentityNo,PersonalDataForm_DateOfBirth,PersonalDataForm_NationalityId, PersonalDataForm_GenderId,*
  FROM [aspnet-BaSaleh].[dbo].[Mig_01_]
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_DateOfBirth is null
  -- where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId is null
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_GenderId is null
--where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_IdentityNo is null
--where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_PlaceOfBirth is null
where [aspnet-BaSaleh].[dbo].[Mig_01_].MonthlyIncomeData_MonthlyIncomeId is null
  --UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = case	when [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = N'«·”⁄ÊœÌ…' then  1
		--																		when [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = N'„’—' then 3
		--																		else [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId end

  UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  set [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = 1
  where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId is NULL


  --  UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_DateOfBirth = ''
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_DateOfBirth is NULL


  --    UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_IdentityNo = '0000000000'
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_IdentityNo is NULL


  --      UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_PlaceOfBirth = ''
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_PlaceOfBirth is NULL

  /********************************/

  select AccommodationData_AccommodationTypeId
    FROM [aspnet-BaSaleh].[dbo].[Mig_01_]
  AccommodationData_AccommodationTypeId
  where AccommodationData_AccommodationTypeId is NULL
          
		--  UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_AccommodationTypeId = '99'
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_AccommodationTypeId is NULL

  --		  UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  --set [aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_Others = ''
  --where [aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_Others is NULL


    UPDATE [aspnet-BaSaleh].[dbo].[Mig_01_]
  set	[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Email = case when ContactInformation_Email is null then '' ELSE ContactInformation_Email end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Mobile = case when ContactInformation_Mobile is null then '' ELSE ContactInformation_Mobile end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_PhoneNumber = case when ContactInformation_PhoneNumber is null then '' ELSE ContactInformation_PhoneNumber end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Facebook = case when ContactInformation_Facebook is null then '' ELSE ContactInformation_Facebook end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Twitter = case when ContactInformation_Twitter is null then '' ELSE ContactInformation_Twitter end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Instagram = case when ContactInformation_Instagram is null then '' ELSE ContactInformation_Instagram end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].ContactInformation_Others = case when ContactInformation_Others is null then '' ELSE ContactInformation_Others end,

		[aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_Others = case when AccommodationData_Others is null then '' ELSE AccommodationData_Others end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].AccommodationData_AccommodationTypeId = case when AccommodationData_AccommodationTypeId is null then '99' ELSE AccommodationData_AccommodationTypeId end,
  
  		[aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_PlaceOfBirth = case when PersonalDataForm_PlaceOfBirth is null then '' ELSE PersonalDataForm_PlaceOfBirth end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_IdentityNo = case when PersonalDataForm_IdentityNo is null then '0000000000' ELSE PersonalDataForm_IdentityNo end,
		[aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_DateOfBirth = case when PersonalDataForm_DateOfBirth is null then '' ELSE PersonalDataForm_DateOfBirth end,
  [aspnet-BaSaleh].[dbo].[Mig_01_].EducationalData_EducationalLevelId = case when EducationalData_EducationalLevelId is null then '99' ELSE EducationalData_EducationalLevelId end,
  
     [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = case	when [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = N'«·”⁄ÊœÌ…' then  1
																				when [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId = N'„’—' then 3
																				else [aspnet-BaSaleh].[dbo].[Mig_01_].PersonalDataForm_NationalityId end,

	[aspnet-BaSaleh].[dbo].[Mig_01_].HealthStatusData_Description = case when HealthStatusData_Description is null then '' ELSE HealthStatusData_Description end,
	[aspnet-BaSaleh].[dbo].[Mig_01_].HealthStatusData_Others = case when HealthStatusData_Others is null then '' ELSE HealthStatusData_Others end,
	  [aspnet-BaSaleh].[dbo].[Mig_01_].HealthStatusData_HealthStatusId = case when HealthStatusData_HealthStatusId is null then '99' ELSE HealthStatusData_HealthStatusId end,
	   [aspnet-BaSaleh].[dbo].[Mig_01_].MaritalStatusData_MaritalStatusId = case when MaritalStatusData_MaritalStatusId is null then '99' ELSE MaritalStatusData_MaritalStatusId end
	  
	
  /******************/