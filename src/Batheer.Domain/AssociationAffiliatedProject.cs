using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{

    /// <summary>
    /// أنواع المشروعات التي تقدمها كل جمعية 
    /// </summary>
    public class AssociationAffiliatedProject : AuditableEntity
    {
        public int Id { get; set; }
        public int CouncilProjectId { get; set; }
        public virtual CouncilProject CouncilProject { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public virtual AssociationsAffiliatedWithTheCouncil AssociationsAffiliatedWithTheCouncil { get; set; }


        public string AboutTheProject { get; set; }
        public string Notes { get; set; }
        public string ProjectName { get; set; }

        public ICollection<AssociationAffiliatedProjectFamilyNeedDetail> AssociationAffiliatedProjectFamilyNeedDetails { get; set; } = new List<AssociationAffiliatedProjectFamilyNeedDetail>();
    }
}
