using Batheer.Application.Common.Mappings;

namespace Batheer.Application.Modules.Lookups.Queries.GetTowns
{
    public class TownDto :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.Town>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
    }
}
