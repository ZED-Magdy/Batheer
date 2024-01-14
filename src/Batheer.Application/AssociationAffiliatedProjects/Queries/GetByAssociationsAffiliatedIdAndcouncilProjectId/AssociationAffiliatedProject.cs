using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationAffiliatedProjects.Queries.GetByAssociationsAffiliatedIdAndcouncilProjectId
{
    public class AssociationAffiliatedProject : IMapFrom<Domain.AssociationAffiliatedProject>
    {
        public int Id { get; set; }
        public int CouncilProjectId { get; set; }
        public string CouncilProjectName { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
        public string AboutTheProject { get; set; }
        public string Notes { get; set; }
        public string ProjectName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.AssociationAffiliatedProject, AssociationAffiliatedProject>()
                .ForMember(d => d.ProjectName, opt => opt.MapFrom(a => a.CouncilProject.Name));

            profile.CreateMap<Domain.AssociationAffiliatedProject, AssociationAffiliatedProject>()
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(s => s.AssociationsAffiliatedWithTheCouncil.Name));
        }

    }
}
