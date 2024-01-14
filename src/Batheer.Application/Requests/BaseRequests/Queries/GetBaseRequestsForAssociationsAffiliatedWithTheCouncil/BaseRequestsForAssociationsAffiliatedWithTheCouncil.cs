using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.BaseRequests.Queries.GetBaseRequestsForAssociationsAffiliatedWithTheCouncil
{
    public class BaseRequestsForAssociationsAffiliatedWithTheCouncil : IMapFrom<FamilyRegistrationRequest>
    {
        public int Id { get; set; }
        public int AssociationAffiliatedProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CouncilProjectName { get; set; }


        public int PersonalDataFormId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }

        public string IdentityNo { get; set; }



        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Domain.AssociationAffiliatedProjects.BaseRequest, BaseRequestsForAssociationsAffiliatedWithTheCouncil>()
            //    .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.AssociationAffiliatedProject.ProjectName));

            profile.CreateMap<FamilyRegistrationRequest, BaseRequestsForAssociationsAffiliatedWithTheCouncil>()
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(s => s.CouncilProject.Name))
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
