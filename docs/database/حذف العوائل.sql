/*
SELECT c.Name, p.* --, IdentityNo,p.* 
from dbo.PersonalDataForm p
inner join dbo.ResponsibleFamilyMembers rfm on rfm.PersonalDataFormId = p.Id
inner join dbo.Families f on f.ResponsibleFamilyMemberId = rfm.Id
inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
inner join dbo.AssociationsAffiliatedWithTheCouncils c on c.id = frr.AssociationsAffiliatedWithTheCouncilId
where LEN(TRIM(IdentityNo)) <> 10
order by c.Id
*/
SELECT c.Name, p.* --, IdentityNo,p.* 
from dbo.PersonalDataForm p
inner join dbo.ResponsibleFamilyMembers rfm on rfm.PersonalDataFormId = p.Id
inner join dbo.Families f on f.ResponsibleFamilyMemberId = rfm.Id
inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
inner join dbo.AssociationsAffiliatedWithTheCouncils c on c.id = frr.AssociationsAffiliatedWithTheCouncilId
where p.IdentityNo = '1039225816'
order by c.Id

SELECT * from FamilyMembers

SELECT c.Name, fm.FamilyId, p.* --, IdentityNo,p.* 
from dbo.PersonalDataForm p
inner join dbo.FamilyMembers fm on fm.PersonalDataFormId = p.Id
inner join dbo.Families f on f.Id = fm.FamilyId
inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
inner join dbo.AssociationsAffiliatedWithTheCouncils c on c.id = frr.AssociationsAffiliatedWithTheCouncilId
where p.IdentityNo = '1039225816'
order by c.Id


SELECT * from dbo.Users where UserName = 'user_153'

SELECT p.IdentityNo, count(p.IdentityNo) 
from dbo.PersonalDataForm p
GROUP by p.IdentityNo
HAVING count(p.IdentityNo) > 1



BEGIN transaction
DECLARE @PersonalDataFormId int = 809
DECLARE @IdentityFileId int, @PersonalPhotoFileId int;

SELECT @IdentityFileId = IdentityFileId, @PersonalPhotoFileId = PersonalPhotoFileId from dbo.PersonalDataForm where id = @PersonalDataFormId


DECLARE @HealthStatusDataId int, @EducationalDataId int, @MaritalStatusDataId int, @OccupationDataId int, @ResponsibleFamilyMemberId int

SELECT @ResponsibleFamilyMemberId = id, @HealthStatusDataId = HealthStatusDataId, @EducationalDataId = EducationalDataId, @MaritalStatusDataId = MaritalStatusDataId, @OccupationDataId = OccupationDataId  
from ResponsibleFamilyMembers where PersonalDataFormId = @PersonalDataFormId

DECLARE @familyId int,
@ContactInformationId int,
@ResidencyAddressDataId int,
@AccommodationDataId int,
@MonthlyIncomeDataId int,
@SocialSecurityDataId int

SELECT @familyId = id, 
@ContactInformationId = ContactInformationId,
@ResidencyAddressDataId = ResidencyAddressDataId,
@AccommodationDataId = AccommodationDataId,
@MonthlyIncomeDataId = MonthlyIncomeDataId,
@SocialSecurityDataId =SocialSecurityDataId
from dbo.Families where ResponsibleFamilyMemberId = @ResponsibleFamilyMemberId

DECLARE @FamilyRegistrationRequestId int

SELECT @FamilyRegistrationRequestId = id from dbo.FamilyRegistrationRequests where FamilyId = @familyId






DELETE from dbo.FamilyNeedData where FamilyRegistrationRequestId = @FamilyRegistrationRequestId

DELETE from dbo.FamilyRegistrationRequests where id = @FamilyRegistrationRequestId

DELETE from dbo.Families where id = @familyId
DELETE from dbo.ContactInformationData where id = @ContactInformationId
DELETE from dbo.ResidencyAddressData where id = @ResidencyAddressDataId
DELETE from dbo.AccommodationData where id = @AccommodationDataId
DELETE from dbo.MonthlyIncomeData where id = @MonthlyIncomeDataId
DELETE from dbo.SocialSecurityData where id = @SocialSecurityDataId

DELETE from ResponsibleFamilyMembers where id= @ResponsibleFamilyMemberId

DELETE FROM dbo.PersonalDataForm where id = @PersonalDataFormId
DELETE FROM dbo.UploadedFiles where id  in( @IdentityFileId,@PersonalPhotoFileId)

DELETE from dbo.HealthStatusData WHERE Id = @HealthStatusDataId
DELETE from dbo.EducationalData where id = @EducationalDataId
DELETE from dbo.MaritalStatusData where id = @MaritalStatusDataId
DELETE from dbo.OccupationData where id = @OccupationDataId


ROLLBACK
--COMMIT


select objectkey, * from dbo.Families