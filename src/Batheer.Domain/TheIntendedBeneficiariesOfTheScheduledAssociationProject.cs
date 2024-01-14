using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// المستفيدين المستهدفين لمشروع الجمعية المجدولة
    /// </summary>
    public class TheIntendedBeneficiariesOfTheScheduledAssociationProject
    {
        public int Id { get; set; }
        public int TargetedSchedulingForProjectImplementationId { get; set; }
        public virtual TargetedSchedulingForProjectImplementation TargetedSchedulingForProjectImplementation { get; set; }
        public virtual ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject { get; set; }
        //public int? ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectId { get; set; }


        //public int FamilyRegistrationRequestId { get; set; }
        //public virtual FamilyRegistrationRequest FamilyRegistrationRequest { get; set; }

        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? IsDeletedDate { get; set; }
        public string IsDeletedBy { get; set; }


        public string SmsSuccessReferenceNo { get; set; }
        public string SmsSentResult { get; set; }
        public DateTime? SmsSentDate { get; set; }
    }
}
