using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class MonthlyIncomeData : AuditableEntity
    {
        public int Id { get; set; }
        public int MonthlyIncomeId { get; set; }
        public virtual Lookups.MonthlyIncome MonthlyIncome { get; set; }
    }
}
