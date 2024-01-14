using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetAssociationsAffiliatedWithTheCouncilInfos
{
    public class CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TownDto> Towns { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<City, CitiesWithAssociationsAffiliatedWithTheCouncilInfoDto>();
        }

    }

    public class TownDto :
        IMapFrom<Town>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AssociationsAffiliatedWithTheCouncilInfoDto> AssociationsAffiliatedWithTheCouncilInfos { get; set; }

    }

}
