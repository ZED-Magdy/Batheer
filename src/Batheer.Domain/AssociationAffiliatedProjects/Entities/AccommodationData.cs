using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class AccommodationData : AuditableEntity
    {
        public int Id { get; set; }

        public int AccommodationTypeId { get; set; }
        public virtual Lookups.AccommodationType AccommodationType { get; set; }

        public string Others { get; set; }
    }
}
