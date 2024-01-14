using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using System;

namespace Batheer.Application.VisitingFamilyMemberResults.Queries.GetVisitingFamilyResultsByCreatedBy
{
    public class VisitingFamilyMemberResultDto : IMapFrom<VisitingFamilyMemberResult>
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public string DidYouVisitTheFamilyMember { get; set; }
        public string GeneralNots { get; set; }
        public string IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
        public Guid ObjectKey { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string FullName { get; set; }
        public string IdentityNo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<VisitingFamilyMemberResult, VisitingFamilyMemberResultDto>()
                .ForMember(f => f.DidYouVisitTheFamilyMember, to => to.MapFrom(s => s.DidYouVisitTheFamilyMember ? "نعم" : "لا"))
                .ForMember(f => f.IsDeserveSupport, to => to.MapFrom(s => s.IsDeserveSupport ? "نعم" : "لا"))

                .ForMember(f => f.FullName, to => to.MapFrom(s =>
                $"{s.FamilyMember.PersonalDataForm.FirstName} {s.FamilyMember.PersonalDataForm.FatherName} {s.FamilyMember.PersonalDataForm.GrandFatherName} {s.FamilyMember.PersonalDataForm.FamilyName}"
                ))
                .ForMember(f => f.IdentityNo, to => to.MapFrom(s => s.FamilyMember.PersonalDataForm.IdentityNo))
                ;
        }
    }
}
