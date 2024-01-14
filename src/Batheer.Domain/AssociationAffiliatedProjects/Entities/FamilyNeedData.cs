using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class FamilyNeedData : AuditableEntity
    {
        public int Id { get; set; }
        public int FamilyNeedId { get; set; }
        public virtual Lookups.FamilyNeed FamilyNeed { get; set; }

        public int FamilyRegistrationRequestId { get; set; }
    }
}
