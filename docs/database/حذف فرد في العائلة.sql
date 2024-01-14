SELECT * from dbo.PersonalDataForm where IdentityNo = '1111198121'-- '١١١١١٩٨١٢١'

select * from dbo.FamilyMembers where PersonalDataFormId in (12413,12414)
select * from dbo.ResponsibleFamilyMembers where id = 4227
select * from dbo.PersonalDataForm where id = 4233
select * from dbo.Families where id in (4227)

select * from dbo.Users where UserName = 'user_153'



BEGIN transaction
select * from dbo.FamilyMembers where PersonalDataFormId in (12413)
DELETE from dbo.FamilyMembers where PersonalDataFormId  = 12413
DELETE from dbo.HealthStatusData where id = 12413
DELETE from dbo.EducationalData where id = 12413

SELECT * from dbo.PersonalDataForm where id = 12413

DELETE from dbo.PersonalDataForm where id = 12413
DELETE from dbo.UploadedFiles where id in (24902,24903)

ROLLBACK
