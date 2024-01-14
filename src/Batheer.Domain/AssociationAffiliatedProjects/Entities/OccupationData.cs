using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class OccupationData : AuditableEntity
    {
        public int Id { get; set; }
        public int OccupationId { get; set; }
        public virtual Occupation Occupation { get; set; }

    }
}
