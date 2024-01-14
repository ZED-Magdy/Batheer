using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.TargetedSchedulingForProjectImplementations.Queries.GetTargetedSchedulingForProjectImplementations
{
    public class TargetedSchedulingForProjectImplementation : IMapFrom<Domain.TargetedSchedulingForProjectImplementation>
    {
        public int Id { get; set; }

        public int AssociationAffiliatedProjectId { get; set; }
        public int CouncilProjectId { get; set; }
        public string CouncilProjectName { get; set; }
        public string ProjectName { get; set; }

        public string AssociationsAffiliatedWithTheCouncilName { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int TargetedSchedulingForProjectImplementationStatusId { get; set; }
        public string TargetedSchedulingForProjectImplementationStatusName { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.TargetedSchedulingForProjectImplementation, TargetedSchedulingForProjectImplementation>()
                .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.AssociationAffiliatedProject.ProjectName));

            profile.CreateMap<Domain.TargetedSchedulingForProjectImplementation, TargetedSchedulingForProjectImplementation>()
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(s => s.AssociationAffiliatedProject.AssociationsAffiliatedWithTheCouncil.Name));
        }

    }
}
