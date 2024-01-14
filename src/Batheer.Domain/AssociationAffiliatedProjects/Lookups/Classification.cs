using System.Collections.Generic;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    public class Classification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<AssociationsAffiliatedWithTheCouncilInfo> AssociationsAffiliatedWithTheCouncilInfos { get; set; }
    }
}
