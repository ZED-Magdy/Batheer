using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class EducationalData : AuditableEntity
    {
        public int Id { get; set; }
        public int EducationalLevelId { get; set; }
        public virtual EducationalLevel EducationalLevel { get; set; }

    }
}
