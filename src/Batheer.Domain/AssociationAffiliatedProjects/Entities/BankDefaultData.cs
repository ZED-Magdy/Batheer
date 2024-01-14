using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /// <summary>
    /// هل هناك تخلف بنكي؟
    /// </summary>
    public class BankDefaultData : AuditableEntity
    {
        public int Id { get; set; }

        /// <summary>
        /// هل هناك تخلف بنكي؟
        /// </summary>
        public bool IsThereABankDefault { get; set; }
    }
}
