using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    /// <summary>
    /// احتياجات العائلة
    /// 
    ///         مأكل ومشرب
    ///         ملبس
    ///         فواتير
    ///         مسكن
    ///         سيولة نقدية
    /// </summary>
    public class FamilyNeed
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FamilyNeedDetail> FamilyNeedDetails { get; set; } = new List<FamilyNeedDetail>();
    }
}
