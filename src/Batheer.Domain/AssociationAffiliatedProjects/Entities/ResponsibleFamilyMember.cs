using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /// <summary>
    /// المسؤول عن العائلة
    /// بالإضافة إلى أنه مقدم الطلب
    /// </summary>
    public class ResponsibleFamilyMember : AuditableEntity
    {
        public int Id { get; set; }

        //public int FamilyId { get; set; }
        //public Family Family { get; set; }


        public virtual PersonalDataForm PersonalDataForm { get; set; }
        public int PersonalDataFormId { get; set; }
        public virtual HealthStatusData HealthStatusData { get; set; }
        public int HealthStatusDataId { get; set; }

        public virtual EducationalData EducationalData { get; set; }
        public int EducationalDataId { get; set; }

        public int MaritalStatusDataId { get; set; }
        public virtual Entities.MaritalStatusData MaritalStatusData { get; set; }


        public int OccupationDataId { get; set; }
        public virtual Entities.OccupationData OccupationData { get; set; }

    }
}
