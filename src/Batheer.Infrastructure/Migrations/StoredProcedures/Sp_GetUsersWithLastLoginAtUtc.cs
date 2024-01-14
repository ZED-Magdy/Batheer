using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class Sp_GetUsersWithLastLoginAtUtc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"

create OR alter PROCEDURE [dbo].[sp_GetUsersWithLastLoginAtUtc]
as
BEGIN

SELECT u.[UserName]
      ,u.[FullName]
      ,u.[Mobile]
      ,[PhotoId]
	  , uf.ObjectKey PhotoObjectkey
      ,[IsActive]
	  ,[UserRole]
      ,ur.name 'UserRoleName'
      ,[LastLoginAtUtc]
	  ,c.Name 'CouncilName'
	  ,fa.LastModified 'Families_LastModified'
	  ,fm.LastModified 'FamilyMembers_LastModified'
	  ,b.LastModified 'AssociationAffiliatedProjects_LastModified'

  FROM [dbo].[Users] u with(nolock)
  inner join userroles ur with(nolock) on ur.id = u.UserRole
  inner join UploadedFiles uf with(nolock) on uf.id = u.PhotoId
  left join AssociationsAffiliatedWithTheCouncilUsers cu with(nolock) on cu.UserName = u.UserName
  left join AssociationsAffiliatedWithTheCouncils c with(nolock) on c.Id = cu.AssociationsAffiliatedWithTheCouncilId

  outer apply (
  select top 1 ISNULL( _f.LastModified , _f.Created) LastModified
  from Families _f  with(nolock)
  where (_f.LastModifiedBy = u.UserName
  or _f.CreatedBy = u.UserName)
  order by 1 desc
  ) fa

  
  outer apply (
  select top 1 ISNULL( _fm.LastModified ,_FM.Created) LastModified
  from FamilyMembers _fm  with(nolock)
  where (_fm.LastModifiedBy = u.UserName
  OR _FM.CreatedBy = U.UserName)
  order by 1 desc
  ) fm

  outer apply (
  select top 1 ISNULL( _b.LastModified, _B.Created) LastModified
  from AssociationAffiliatedProjects _b with(nolock)
  where (_b.LastModifiedBy = u.UserName
  OR _B.CreatedBy = U.UserName)
  order by 1 desc
  ) b


  order by ur.id, c.id

END
GO



";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
