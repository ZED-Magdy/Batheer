using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.DeliveryAids.Queries.SearchByReceivedCode
{
    public class SearchByReceivedCodeDto : IMapFrom<TheIntendedBeneficiariesOfTheScheduledAssociationProject>
    {
        public int BaseRequestId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName { get; set; }

        public string CouncilProjectName { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
        public string ProjectName { get; set; }
        public string DeliveryStatusName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<TheIntendedBeneficiariesOfTheScheduledAssociationProject, SearchByReceivedCodeDto>()
                .ForMember(d => d.BaseRequestId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName))
                .ForMember(d => d.FatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName))
                .ForMember(d => d.GrandFatherName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName))
                .ForMember(d => d.FamilyName, opt => opt.MapFrom(s => s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s =>
                 $"{s.Family.ResponsibleFamilyMember.PersonalDataForm.FirstName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.GrandFatherName} {s.Family.ResponsibleFamilyMember.PersonalDataForm.FamilyName}"
                ))
                .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.CouncilProject.Name))
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(s => s.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name))
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.ProjectName))
                .ForMember(d => d.FromDate, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.FromDate))
                .ForMember(d => d.ToDate, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.ToDate))

                .ForMember(d => d.DeliveryStatusName, opt => opt.MapFrom(a => a.ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject == null ? "جديد" : "تم التسليم"));


        }
    }
}
