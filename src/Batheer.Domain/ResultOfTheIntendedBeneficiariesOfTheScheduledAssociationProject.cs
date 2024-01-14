using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// نتيجة المستفيدين المستهدفين في كل جمعية لكل مشروع لكل جدولة زمنية (تسليم الإعانات وصول المساعدات) 
    /// </summary>
    public class ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject
    {
        public int Id { get; set; }

        public int TheIntendedBeneficiariesOfTheScheduledAssociationProjectId { get; set; }

        public virtual TheIntendedBeneficiariesOfTheScheduledAssociationProject TheIntendedBeneficiariesOfTheScheduledAssociationProject { get; set; }
        public string Notes { get; set; }

        public int ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatusId { get; set; }
        public virtual ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus { get; set; }

        public virtual ICollection<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachment> ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectAttachments { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
