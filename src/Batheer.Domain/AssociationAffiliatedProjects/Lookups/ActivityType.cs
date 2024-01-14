using System.Collections.Generic;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AssociationsAffiliatedWithTheCouncilInfoActivityType> AssociationActivityTypes { get; set; }

    }
}
