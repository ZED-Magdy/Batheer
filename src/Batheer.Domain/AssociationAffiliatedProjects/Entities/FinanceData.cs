using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /*
     
     سيارات الأجرة
عربات البيع
الأكشاك
الكورنرات
الأسر المنتجة
توطين المتاجر
     */
    public class FinanceData : AuditableEntity
    {
        public int Id { get; set; }

        public int FinanceTypeId { get; set; }
        public virtual Lookups.FinanceType FinanceType { get; set; }

        /// <summary>
        /// إذا الاختيار أسر منتجة اختر من القائمة التالية:
        /// </summary>
        public int? ProducedFamilyProductId { get; set; }
        public virtual Lookups.ProducedFamilyProduct ProducedFamilyProduct { get; set; }
    }
}
