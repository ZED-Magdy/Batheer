using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.Common;

namespace Batheer.Domain
{
    public class AssociationsAffiliatedWithTheCouncilInfoActivityType : AuditableEntity
    {
        public int Id { get; set; }
        public int AssociationsAffiliatedWithTheCouncilInfoId { get; set; }
        public AssociationsAffiliatedWithTheCouncilInfo AssociationsAffiliatedWithTheCouncilInfo { get; set; }

        public ActivityType ActivityType { get; set; }
        public int ActivityTypeId { get; set; }
    }
}
