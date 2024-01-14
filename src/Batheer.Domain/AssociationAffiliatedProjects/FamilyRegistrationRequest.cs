using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects
{
    /// <summary>
    /// طلب تسجيل عائلة
    /// </summary>
    public class FamilyRegistrationRequest : AuditableEntity
    {
        public FamilyRegistrationRequest()
        {
            TheIntendedBeneficiariesOfTheScheduledAssociationProjects = new List<TheIntendedBeneficiariesOfTheScheduledAssociationProject>();
        }
        public int Id { get; set; }

        public int CouncilProjectId { get; set; }
        public virtual CouncilProject CouncilProject { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public virtual AssociationsAffiliatedWithTheCouncil AssociationsAffiliatedWithTheCouncil { get; set; }

        public virtual ICollection<TheIntendedBeneficiariesOfTheScheduledAssociationProject> TheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }


        public int FamilyId { get; set; }
        public virtual Entities.Family Family { get; set; }


        public int FamilyCategoryId { get; set; }
        public virtual Lookups.FamilyCategory FamilyCategory { get; set; }

        public virtual ICollection<Entities.FamilyNeedData> FamilyNeedData { get; set; } = new List<Entities.FamilyNeedData>();

    }
}
