using Batheer.Domain.AssociationAffiliatedProjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// تصنيف المشروعات
    /// مشاريع مستهدفة من المجلس 
    /// </summary>
    public class CouncilProject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FamilyRegistrationRequest> FamilyRegistrationRequests { get; set; } = new List<FamilyRegistrationRequest>();
    }
}
