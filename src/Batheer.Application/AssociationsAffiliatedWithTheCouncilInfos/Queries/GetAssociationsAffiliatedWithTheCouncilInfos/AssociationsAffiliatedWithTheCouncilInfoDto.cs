using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncilInfos.Queries.GetAssociationsAffiliatedWithTheCouncilInfos
{
    public class AssociationsAffiliatedWithTheCouncilInfoDto : IMapFrom<Domain.AssociationsAffiliatedWithTheCouncilInfo>
    {
        public int Id { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public string AssociationsAffiliatedWithTheCouncilName { get; set; }
        public string President_Name { get; set; }
        public string President_Mobile { get; set; }
        public string VicePresident_Mobile { get; set; }
        public string VicePresident_Name { get; set; }
        public string Manager_Mobile { get; set; }
        public string Manager_Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? MembershipDate { get; set; }
        public DateTime? MembershipEndDate { get; set; }
        public string EmployeesCount { get; set; }
        public string MembersCount { get; set; }
        public string GeneralMembersCount { get; set; }
        public string LocationOnGoogleMap { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public string WebsiteUrl { get; set; }
        public int? ClassificationId { get; set; }
        public string ClassificationName { get; set; }

        public Guid objectkey { get; set; }

        public string CityName { get; set; }
        public int CityId { get; set; }

        public string TownName { get; set; }
        public int TownId { get; set; }

        public List<ActivityTypeDto> ActivityTypes { get; set; }

        public void Mapping(Profile profile)
        {
            profile
                .CreateMap<Domain.AssociationsAffiliatedWithTheCouncilInfo, AssociationsAffiliatedWithTheCouncilInfoDto>();
        }

    }

    public class ActivityTypeDto :
        IMapFrom<AssociationsAffiliatedWithTheCouncilInfoActivityType>
    {
        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AssociationsAffiliatedWithTheCouncilInfoActivityType, ActivityTypeDto>()
                .ForMember(d => d.ActivityTypeId, opt => opt.MapFrom(s => s.ActivityTypeId))
                .ForMember(d => d.ActivityTypeName, opt => opt.MapFrom(s => s.ActivityType.Name));
        }

    }
}
