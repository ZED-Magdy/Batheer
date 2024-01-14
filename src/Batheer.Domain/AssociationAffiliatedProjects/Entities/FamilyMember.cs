using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /// <summary>
    /// فرد من العائلة
    /// </summary>
    public class FamilyMember : AuditableEntity, ISoftDeletabe
    {
        public int Id { get; set; }

        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }


        public virtual PersonalDataForm PersonalDataForm { get; set; }
        public int PersonalDataFormId { get; set; }
        public virtual HealthStatusData HealthStatusData { get; set; }
        public int HealthStatusDataId { get; set; }

        public virtual EducationalData EducationalData { get; set; }
        public int EducationalDataId { get; set; }
        public Guid objectkey { get; set; }

        public bool IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeleteNotes { get; set; }
    }
}
