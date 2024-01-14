using Batheer.Application.Common.Mappings;

namespace Batheer.Application.Modules.Lookups.Queries.GetClassifications
{
    public class Classification :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.Classification>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
