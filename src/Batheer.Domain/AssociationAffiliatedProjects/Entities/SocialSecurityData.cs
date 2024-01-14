using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class SocialSecurityData : AuditableEntity
    {
        public int Id { get; set; }

        public bool AreYouABeneficiaryOfSocialSecurity { get; set; }

        /// <summary>
        /// اسم الجمعية المسجل فيها إن وجدت
        /// </summary>
        public string Description { get; set; }
    }
}
