using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{

    public class FamilyNeedDetail
    {
        public int Id { get; set; }
        public int FamilyNeedId { get; set; }
        public virtual FamilyNeed FamilyNeed { get; set; }
        public string Name { get; set; }

        public ICollection<AssociationAffiliatedProjectFamilyNeedDetail> AssociationAffiliatedProjectFamilyNeedDetails { get; set; } = new List<AssociationAffiliatedProjectFamilyNeedDetail>();

    }
}
