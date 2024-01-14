using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.BaseRequests.Queries.GetFamiliesByCouncilId
{
    public class GetFamiliesByCouncilIdDto : IMapFrom<FamilyRegistrationRequest>
    {
        public int Id { get; set; }
        public int AssociationAffiliatedProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CouncilProjectName { get; set; }
        public string CouncilName { get; set; }

        public int FamilyId { get; set; }

        public int PersonalDataFormId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }

        public string IdentityNo { get; set; }
        public bool HasSupportingFamilyRequest { get; set; }

        public Guid? IdentityFileObjectKey { get; set; }
        public Guid? PersonalPhotoFileObjectKey { get; set; }
        public bool ResidencyAddressData_IsOutOfTabuk { get; set; }
        public string MonthlyIncome_Name { get; set; }
        public string Nationality_ISO_CODES { get; set; }
        public string FamilyCategory_Name { get; set; }
        public List<string> FamilyNeeds { get; set; }
        public DateTime Created { get; set; }

        public Guid objectkey { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<Domain.AssociationAffiliatedProjects.BaseRequest, BaseRequestsForAssociationsAffiliatedWithTheCouncil>()
            //    .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.AssociationAffiliatedProject.ProjectName));

            profile.CreateMap<FamilyRegistrationRequest, GetFamiliesByCouncilIdDto>()
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(s => s.CouncilProject.Name))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName))
                .ForMember(d => d.FatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName))
                .ForMember(d => d.GrandFatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName))
                .ForMember(d => d.IdentityNo, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityNo))
                .ForMember(d => d.HasSupportingFamilyRequest, opt => opt.MapFrom(s => s.Family.SupportingFamilyRequest != null))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ))

                .ForMember(d => d.IdentityFileObjectKey, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.IdentityFile.ObjectKey))
                .ForMember(d => d.PersonalPhotoFileObjectKey, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.PersonalPhotoFile.ObjectKey))
                
                .ForMember(d => d.ResidencyAddressData_IsOutOfTabuk, opt => opt.MapFrom(s => s.Family.ResidencyAddressData.IsOutOfTabuk))
                .ForMember(d => d.MonthlyIncome_Name, opt => opt.MapFrom(s => s.Family.MonthlyIncomeData.MonthlyIncome.Name))
                .ForMember(d => d.Nationality_ISO_CODES, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.Nationality.ISO_CODES))
                .ForMember(d => d.FamilyCategory_Name, opt => opt.MapFrom(s => s.FamilyCategory.Name))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.FamilyNeeds, opt => opt.MapFrom(s => s.FamilyNeedData.Select(s => s.FamilyNeed.Name)))

                .ForMember(d=> d.objectkey, opt=> opt.MapFrom(s=> s.Family.objectkey))

                .ForMember(d => d.CouncilName, opt => opt.MapFrom(s => s.AssociationsAffiliatedWithTheCouncil.Name))
                ;
        }
    }
}
