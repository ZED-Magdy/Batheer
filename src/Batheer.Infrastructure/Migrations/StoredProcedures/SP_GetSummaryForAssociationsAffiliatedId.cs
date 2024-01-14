using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Infrastructure.Migrations.StoredProcedures
{
    public class SP_GetSummaryForAssociationsAffiliatedId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE [dbo].[SP_GetSummaryForAssociationsAffiliatedId]
	@AssociationsAffiliatedId int
AS
BEGIN
	DECLARE @temp table (Group_Name nvarchar(200), Item_Name nvarchar(200), Value int)



insert into @temp
select N'الطلبات', N'دعم الأسر', count(1) 
from FamilyRegistrationRequests r WITH(NOLOCK)
inner join Families f on f.id = r.FamilyId and f.IsDeleted = 0
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId

insert into @temp
select N'الطلبات', N'تمكين الأسر', count(1) 
from SupportingFamilyRequests sr WITH(NOLOCK)
inner join dbo.Families f WITH(NOLOCK) on f.Id = sr.FamilyId and f.IsDeleted = 0
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId


/**********/

insert into @temp
select N'مكان السكن', N'خارج تبوك', count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.ResidencyAddressData rad WITH(NOLOCK) on rad.id = f.ResidencyAddressDataId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and rad.IsOutOfTabuk = 1
and f.IsDeleted = 0

insert into @temp
select N'مكان السكن', N'داخل تبوك', count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.ResidencyAddressData rad WITH(NOLOCK) on rad.id = f.ResidencyAddressDataId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and rad.IsOutOfTabuk = 0
and f.IsDeleted = 0

/**********/
insert into @temp
select N'الضمان الاجتماعي', N'مسجل', count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.SocialSecurityData ssd WITH(NOLOCK) on ssd.id = f.ResidencyAddressDataId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and ssd.AreYouABeneficiaryOfSocialSecurity = 1
and f.IsDeleted = 0

insert into @temp
select N'الضمان الاجتماعي', N'غير مسجل', count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.SocialSecurityData ssd WITH(NOLOCK) on ssd.id = f.ResidencyAddressDataId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and ssd.AreYouABeneficiaryOfSocialSecurity = 0
and f.IsDeleted = 0


/**********/

insert into @temp
select N'تصنيف الأسرة', fc.Name, count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.FamilyCategories fc WITH(NOLOCK) on fc.id = r.FamilyCategoryId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and f.IsDeleted = 0
GROUP by fc.Name


/*******/

insert into @temp
select N'عدد التابعين', g.Name, count(1) 
from dbo.Families f WITH(NOLOCK)
inner join dbo.FamilyRegistrationRequests r WITH(NOLOCK) on r.FamilyId = f.Id
inner join dbo.FamilyMembers fm WITH(NOLOCK) on fm.FamilyId = f.Id and fm.IsDeleted = 0
inner join dbo.PersonalDataForm p WITH(NOLOCK) on p.Id = fm.PersonalDataFormId
inner join dbo.Genders g WITH(NOLOCK) on g.id = p.GenderId
where AssociationsAffiliatedWithTheCouncilId = @AssociationsAffiliatedId
and f.IsDeleted = 0

GROUP by g.Name





SELECT * from @temp
END
";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
