namespace Batheer.DataMigration.Models
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
