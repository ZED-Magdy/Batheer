using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.TheIntendedBeneficiaries.Queries.GetUnAssignedByTargetedSchedulingForProjectImplementationId
{
    public class UnAssignedToTargetedSchedulingForProjectImplementation : IMapFrom<FamilyRegistrationRequest>
    {
        public int FamilyId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }
        public string IdentityNo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FamilyRegistrationRequest, UnAssignedToTargetedSchedulingForProjectImplementation>()
                .ForMember(d => d.FamilyId, opt => opt.MapFrom(s => s.FamilyId))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName))
                .ForMember(d => d.FatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName))
                .ForMember(d => d.GrandFatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName))
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ));
        }
    }
}
