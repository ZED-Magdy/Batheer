

SELECT p.IdentityNo, count(1), fm.FamilyId-- , f.CreatedBy, f.*

from dbo.FamilyMembers fm
inner join dbo.PersonalDataForm p on p.id = fm.PersonalDataFormId
inner join dbo.Families f on f.id = fm.FamilyId
inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
--inner join dbo.AssociationsAffiliatedWithTheCouncils co on co.id = frr.AssociationsAffiliatedWithTheCouncilId
group by p.IdentityNo, fm.FamilyId
HAVING count(1) > 1
order by fm.FamilyId --p.IdentityNo


SELECT p.IdentityNo, count(1)
from dbo.PersonalDataForm p
--inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
--inner join dbo.AssociationsAffiliatedWithTheCouncils co on co.id = frr.AssociationsAffiliatedWithTheCouncilId
group by p.IdentityNo --, f.id
HAVING count(1) > 1
--order by f.Id --p.IdentityNo




SELECT p.IdentityNo,  f.objectkey , fm.CreatedBy, u.Password, f.*

from dbo.FamilyMembers fm
inner join dbo.PersonalDataForm p on p.id = fm.PersonalDataFormId
inner join dbo.Families f on f.id = fm.FamilyId
inner join dbo.FamilyRegistrationRequests frr on frr.FamilyId = f.Id
inner join dbo.Users u on u.UserName = fm.CreatedBy
where f.id in (
2148
,2878
,4334
,5242
,5480
,5547
,5547
,5547
,5548
,5682
,5707
,5707
,5707
,5889
,6432
,7360
,7360
,7415
,9494
)
and p.IdentityNo in 
(
'1056965310'
,'1128011259'
,'1087900245'
,'1149748160'
,'1119078085'
,'1112145477'
,'1139828527'
,'1144536271'
,'1115536722'
,'1148657693'
,'1115364323'
,'1130493289'
,'1146002694'
,'1113650954'
,'1040556878'
,'1045073556'
,'1097770455'
,'1192110912'
,'1018567774'
)
order by u.UserName




with a as (
SELECT p.IdentityNo , count(1) _count
from dbo.PersonalDataForm p
group by p.IdentityNo --, f.id
HAVING count(1) > 1
)

SELECT rm.id, rm.CreatedBy, f.Created, u.Password, f.objectkey, f.id, * from a
inner JOIN dbo.PersonalDataForm p on p.IdentityNo = a.IdentityNo
left JOIN dbo.ResponsibleFamilyMembers rm on rm.PersonalDataFormId = p.Id
inner join dbo.Users u on u.UserName = rm.CreatedBy
inner join dbo.Families f on f.ResponsibleFamilyMemberId = rm.Id
order by f.Id

