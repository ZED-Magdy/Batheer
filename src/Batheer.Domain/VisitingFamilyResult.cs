using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.Common;
using System;

namespace Batheer.Domain
{
    public class VisitingFamilyResult : AuditableEntity
    {
        public int Id { get; set; }
        public int FamilyId { get; set; }
        public Family Family { get; set; }

        public bool DidYouVisitTheFamily { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
        public Guid ObjectKey { get; set; } = Guid.NewGuid();

    }
}
