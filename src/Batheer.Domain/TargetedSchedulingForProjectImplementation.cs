using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// الجدولة الزمنية المستهدفة لتنفيذ كل مشروع 
    /// </summary>
    public class TargetedSchedulingForProjectImplementation
    {
        public TargetedSchedulingForProjectImplementation()
        {
            TheIntendedBeneficiariesOfTheScheduledAssociationProjects = new List<TheIntendedBeneficiariesOfTheScheduledAssociationProject>();
        }
        public int Id { get; set; }

        public int AssociationAffiliatedProjectId { get; set; }
        public virtual AssociationAffiliatedProject AssociationAffiliatedProject { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int TargetedSchedulingForProjectImplementationStatusId { get; set; }
        public virtual TargetedSchedulingForProjectImplementationStatus TargetedSchedulingForProjectImplementationStatus { get; set; }

        public virtual ICollection<TheIntendedBeneficiariesOfTheScheduledAssociationProject> TheIntendedBeneficiariesOfTheScheduledAssociationProjects { get; set; }





        /// <summary>
        /// اعتماد قائمة العوائل المستهدفة وإرسال الرسائل
        /// </summary>
        public DateTime? ApprovedDate { get; set; }
        public string ApprovedBy { get; set; }

    }
}
