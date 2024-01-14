using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class HealthStatusData : AuditableEntity
    {
        public int Id { get; set; }

        public int HealthStatusId { get; set; }
        public virtual Lookups.HealthStatus HealthStatus { get; set; }

        public string Others { get; set; }

        /// <summary>
        /// نوع المرض أو الإعاقة إن وجد
        /// </summary>
        public string Description { get; set; }
    }
}
