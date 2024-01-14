using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Models.RequestForms
{
    public class FinanceDataModel
    {
        public int FinanceTypeId { get; set; }

        /// <summary>
        /// إذا الاختيار أسر منتجة اختر من القائمة التالية:
        /// </summary>
        public int? ProducedFamilyProductId { get; set; }
    }
}
