using Batheer.Application.Common.Mappings;

namespace Batheer.Application.Modules.Lookups.Queries.GetCities
{
    public class CityDto :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
