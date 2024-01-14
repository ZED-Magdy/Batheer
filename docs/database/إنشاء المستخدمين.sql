/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[AboutIt]
      ,[AdministrativeRestructuring]
      ,[ContactInformation]
      ,[LocationOnTheMap]
      ,[Email]
      ,[ExecutiveDirectorName]
      ,[ContactNumber]
      ,[CouncilCategory]
  FROM [ngostsa_db].[dbo].[AssociationsAffiliatedWithTheCouncils]
  where Name LIKE N'%„·%'


  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[AssociationsAffiliatedWithTheCouncilId]
      ,[FullName]
      ,[Mobile]
      ,[UserName]
      ,[PhotoUrl]
  FROM [ngostsa_db].[dbo].[AssociationsAffiliatedWithTheCouncilUsers]


  /****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [UserName]
      ,[Password]
      ,[FullName]
      ,[Mobile]
      ,[PhotoId]
      ,[UserRole]
  FROM [ngostsa_db].[dbo].[Users]

  

  DECLARE @UserName nvarchar(50) = N'user_154';
  DECLARE @Password nvarchar(50) = N'123qwe';
  DECLARE @FullName nvarchar(50) = N'„” Œœ„ 1';
  DECLARE @AssociationsAffiliatedWithTheCouncilId int = 154;

  select @Password = FLOOR( RAND() * 1000000)

  
  INSERT into dbo.UploadedFiles ( FileName,ContentType,Content, objectkey)
  select FileName,ContentType,Content, NEWID() 
  from dbo.UploadedFiles where id = 13;

  DECLARE @PhotoId int; -- =2911;
  select @PhotoId = SCOPE_IDENTITY();


INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
           ,[FullName]
           ,[Mobile]
           ,[PhotoId]
           ,[UserRole])
     VALUES
           (@UserName
           ,@Password
           ,@FullName
           ,''
           ,@PhotoId
           ,2)


		   INSERT INTO [dbo].[AssociationsAffiliatedWithTheCouncilUsers]
           ([AssociationsAffiliatedWithTheCouncilId]
           ,[FullName]
           ,[Mobile]
           ,[UserName]
           ,[PhotoUrl])
     VALUES
           (@AssociationsAffiliatedWithTheCouncilId
           ,@FullName
           ,''
           ,@UserName
           ,'')


SELECT u.UserName, u.Password, c.Name
from dbo.Users u
inner join dbo.AssociationsAffiliatedWithTheCouncilUsers cu on cu.UserName = u.UserName
inner join dbo.AssociationsAffiliatedWithTheCouncils c on c.Id = cu.AssociationsAffiliatedWithTheCouncilId
ORDER by c.Name



SELECT u.UserName, u.Password, c.Name, '' FullName, '' Mobile
from dbo.AssociationsAffiliatedWithTheCouncils c
left join dbo.AssociationsAffiliatedWithTheCouncilUsers cu on cu.AssociationsAffiliatedWithTheCouncilId = c.Id
left join  dbo.Users u  on u.UserName = cu.UserName
where u.UserName is NOT NULL
ORDER by c.id
