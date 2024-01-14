using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.Common;
using System;

namespace Batheer.Domain
{
    public class VisitingFamilyMemberResult : AuditableEntity
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }

        public bool DidYouVisitTheFamilyMember { get; set; }
        public string GeneralNots { get; set; }
        public bool IsDeserveSupport { get; set; }
        public string WhyNoDeserveSupport { get; set; }
        public Guid ObjectKey { get; set; } = Guid.NewGuid();

    }
}
