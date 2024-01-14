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

namespace Batheer.Application.Modules.Lookups.Queries.GetNationalities
{
    public class Nationality :
        IMapFrom<Domain.AssociationAffiliatedProjects.Entities.Nationality>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.AssociationAffiliatedProjects.Entities.Nationality, Nationality>()
                .ForMember(d => d.Id, opt => opt.MapFrom(a => a.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(a => a.Name));
        }
    }
}
