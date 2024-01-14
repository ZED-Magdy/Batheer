using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    public class AssociationAffiliatedProjectFamilyNeedDetail
    {
        public int Id { get; set; }
        public int AssociationAffiliatedProjectId { get; set; }
        public AssociationAffiliatedProject AssociationAffiliatedProject { get; set; }

        public int FamilyNeedDetailId { get; set; }
        public FamilyNeedDetail FamilyNeedDetail { get; set; }
    }
}
