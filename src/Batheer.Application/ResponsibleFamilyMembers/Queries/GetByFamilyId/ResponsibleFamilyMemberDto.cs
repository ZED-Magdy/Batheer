using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.ResponsibleFamilyMembers.Queries.GetByFamilyId
{
    public class ResponsibleFamilyMemberDto : IMapFrom<FamilyRegistrationRequest>
    {
        public string FullName { get; set; }
        public string IdentityNo { get; set; }
        public int FamilyRegistrationRequestId { get; set; }
        public int FamilyId { get; set; }
        public void Mapping(Profile profile)
        {

            profile.CreateMap<FamilyRegistrationRequest, ResponsibleFamilyMemberDto>()
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                .ForMember(d => d.FamilyRegistrationRequestId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ));
        }
    }
}
