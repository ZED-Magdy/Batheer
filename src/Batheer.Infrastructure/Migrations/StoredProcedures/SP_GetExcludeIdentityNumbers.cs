using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_GetExcludeIdentityNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
ALTER PROCEDURE [dbo].[SP_GetExcludeIdentityNumbers]
(
	@IdentityNo nvarchar(50),
	@AssociationsAffiliatedWithTheCouncilId int
)
AS
BEGIN





select 
FMC.Name 'CouncilName'
,en.* 
,P.FirstName
,P.FatherName 
,P.GrandFatherName 
,P.FamilyName
, 0 IsFamilyMember
, null FamilyMemberObjectkey
, fm_f.objectkey FamilyObjectkey
from ExcludeIdentityNumbers en

INNER JOIN [dbo].[PersonalDataForm] p ON P.IdentityNo = EN.IdentityNo
inner join ResponsibleFamilyMembers fm on fm.PersonalDataFormId = P.Id
inner join Families fm_f on fm_f.ResponsibleFamilyMemberId = fm.id -- and fm_f.IsDeleted = 0
inner join FamilyRegistrationRequests fm_r on fm_r.FamilyId = fm_f.id
inner join AssociationsAffiliatedWithTheCouncils fmc on fmc.id = fm_r.AssociationsAffiliatedWithTheCouncilId


where (@IdentityNo is null or @IdentityNo = '' or en.IdentityNo = @IdentityNo)
and (@AssociationsAffiliatedWithTheCouncilId is null or @AssociationsAffiliatedWithTheCouncilId = fm_r.AssociationsAffiliatedWithTheCouncilId)


union

select 
FMC.Name 'CouncilName'
,en.* 
,P.FirstName
,P.FatherName 
,P.GrandFatherName 
,P.FamilyName
, 1 IsFamilyMember
, FM.objectkey FamilyMemberObjectkey
, fm_f.objectkey FamilyObjectkey
from ExcludeIdentityNumbers en

INNER JOIN [dbo].[PersonalDataForm] p ON P.IdentityNo = EN.IdentityNo
inner join FamilyMembers fm on fm.PersonalDataFormId = P.Id -- and fm.IsDeleted = 0
inner join Families fm_f on fm_f.id = fm.FamilyId and fm_f.IsDeleted = 0
inner join FamilyRegistrationRequests fm_r on fm_r.FamilyId = fm_f.id
inner join AssociationsAffiliatedWithTheCouncils fmc on fmc.id = fm_r.AssociationsAffiliatedWithTheCouncilId


where (@IdentityNo is null or @IdentityNo = '' or en.IdentityNo = @IdentityNo)
and (@AssociationsAffiliatedWithTheCouncilId is null or @AssociationsAffiliatedWithTheCouncilId = fm_r.AssociationsAffiliatedWithTheCouncilId)





END


";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
