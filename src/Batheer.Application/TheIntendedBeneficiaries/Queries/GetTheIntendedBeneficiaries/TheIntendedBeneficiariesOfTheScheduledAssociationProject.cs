using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Batheer.Application.TheIntendedBeneficiaries.Queries.GetTheIntendedBeneficiaries
{
    public class TheIntendedBeneficiariesOfTheScheduledAssociationProject : IMapFrom<Domain.TheIntendedBeneficiariesOfTheScheduledAssociationProject>
    {
        public int Id { get; set; }
        public int TargetedSchedulingForProjectImplementationId { get; set; }
        public int BaseRequestId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedDate { get; set; }
        public string IsDeletedBy { get; set; }

        public string AssociationsAffiliatedWithTheCouncilName { get; set; }

        public string CouncilProjectName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.TheIntendedBeneficiariesOfTheScheduledAssociationProject, TheIntendedBeneficiariesOfTheScheduledAssociationProject>()
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name));


            profile.CreateMap<Domain.TheIntendedBeneficiariesOfTheScheduledAssociationProject, TheIntendedBeneficiariesOfTheScheduledAssociationProject>()
                .ForMember(d => d.CouncilProjectName, opt => opt.MapFrom(a => a.TargetedSchedulingForProjectImplementation.AssociationAffiliatedProject.CouncilProject.Name));


        }
    }
}
