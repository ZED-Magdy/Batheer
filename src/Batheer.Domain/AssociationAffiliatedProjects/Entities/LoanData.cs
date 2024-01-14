using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class LoanData : AuditableEntity
    {
        public int Id { get; set; }

        public int LoanTypeId { get; set; }
        public virtual Lookups.LoanType LoanType { get; set; }

        public string Others { get; set; }



        /// <summary>
        /// هل لديك قروض أو التزامات أخرى؟
        /// </summary>
        public bool DoYouHaveLoansOrOtherObligations { get; set; }

        public string Description { get; set; }
    }
}
