using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    /// <summary>
    /// أرملة
    /// مطلقة
    /// فقيرة
    /// يتيم
    /// </summary>
    public class FamilyCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public enum FamilyCategories
        {
            /// <summary>
            /// أرملة
            /// </summary>
            Widow = 1,
            /// <summary>
            /// مطلقة
            /// </summary>
            Divorced = 2,
            /// <summary>
            /// فقيرة
            /// </summary>
            Poor = 3,
            /// <summary>
            /// يتيم
            /// </summary>
            Orphan = 4


        }
    }
}
