using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Application.UploadedFiles.Queries.GetByObjectKey;
using Batheer.Domain;
using System;

namespace Batheer.Application.VisitingFamilyResults.Queries.GetVisitingFamilyResultsByFamilyObjectkey
{
    public class VisitingFamilyResultDto : IMapFrom<VisitingFamilyResult>
    {
        public int Id { get; set; }
        public int FamilyId { get; set; }
        public string DidYouVisitTheFamily { get; set; }
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
            profile.CreateMap<VisitingFamilyResult, VisitingFamilyResultDto>()
                .ForMember(f => f.DidYouVisitTheFamily, to => to.MapFrom(s => s.DidYouVisitTheFamily ? "نعم" : "لا"))
                .ForMember(f => f.IsDeserveSupport, to => to.MapFrom(s => s.IsDeserveSupport ? "نعم" : "لا"))


                .ForMember(f => f.FullName, to => to.MapFrom(s =>
                $"{s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ))
                .ForMember(f => f.IdentityNo, to => to.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                ;
        }
    }
}
