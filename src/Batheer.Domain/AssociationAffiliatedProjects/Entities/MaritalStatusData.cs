using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class MaritalStatusData : AuditableEntity
    {
        public int Id { get; set; }
        public int MaritalStatusId { get; set; }
        public virtual Lookups.MaritalStatus MaritalStatus { get; set; }

        public string Others { get; set; }
    }
}
