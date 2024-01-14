using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilUsers.Queries.GetAssociationsAffiliatedWithTheCouncilUsers
{
    public class AssociationsAffiliatedWithTheCouncilUser : IMapFrom<Domain.AssociationsAffiliatedWithTheCouncilUser>
    {
        public int Id { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public Guid PhotoObjectkey { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.AssociationsAffiliatedWithTheCouncilUser, AssociationsAffiliatedWithTheCouncilUser>()
                .ForMember(d => d.AssociationsAffiliatedWithTheCouncilName, opt => opt.MapFrom(a => a.AssociationsAffiliatedWithTheCouncil.Name));

        }
    }
}
