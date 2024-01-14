using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetFamilyNeedsWithDetails
{
    public class FamilyNeedWithDetails :
        IMapFrom<FamilyNeed>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<FamilyNeedDetailsDto> FamilyNeedDetails { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FamilyNeedDetail, FamilyNeedDetailsDto>();
            profile.CreateMap<FamilyNeed, FamilyNeedWithDetails>()
                .ForMember(d => d.FamilyNeedDetails, opt => opt.MapFrom(s => s.FamilyNeedDetails));

        }
    }

    public class FamilyNeedDetailsDto :
        IMapFrom<FamilyNeedDetail>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
