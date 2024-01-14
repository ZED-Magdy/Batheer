using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects
{
    /// <summary>
    /// </summary>
    public class SupportingFamilyRequest : AuditableEntity
    {
        public int Id { get; set; }

        public int FamilyId { get; set; }
        public virtual Entities.Family Family { get; set; }

        public int SupportingFamilyTypeId { get; set; }
        public virtual SupportingFamilyType SupportingFamilyType { get; set; }

        public int BankDefaultDataId { get; set; }
        public virtual Entities.BankDefaultData BankDefaultData { get; set; }
        public int FinanceDataId { get; set; }
        public virtual Entities.FinanceData FinanceData { get; set; }


        public int LoanDataId { get; set; }
        public virtual Entities.LoanData LoanData { get; set; }

        public int ProjectDataId { get; set; }
        public virtual Entities.ProjectData ProjectData { get; set; }


        public int WorkOnAProjectDataId { get; set; }
        public virtual Entities.WorkOnAProjectData WorkOnAProjectData { get; set; }


        public int RequestStatusId { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }

    }
}
