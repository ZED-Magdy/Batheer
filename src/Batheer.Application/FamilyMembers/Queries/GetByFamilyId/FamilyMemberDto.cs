using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.FamilyMembers.Queries.GetByFamilyId
{
    public class FamilyMemberDto : IMapFrom<FamilyMember>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNo { get; set; }
        public string GenderName { get; set; }
        public string NationalityName { get; set; }
        public void Mapping(Profile profile)
        {

            profile.CreateMap<FamilyMember, FamilyMemberDto>()
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.PersonalDataForm.IdentityNo))
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.PersonalDataForm.GenderId.ToString()))
                .ForMember(d => d.NationalityName, opt => opt.MapFrom(s => s.PersonalDataForm.Nationality.Name))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.PersonalDataForm.FirstName} {s.PersonalDataForm.FatherName} {s.PersonalDataForm.GrandFatherName} {s.PersonalDataForm.FamilyName}"
                ));
        }
    }
}
