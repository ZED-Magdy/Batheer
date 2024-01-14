namespace Batheer.DataMigration.Models
{
    public class HealthStatusDataModel
    {
        public int HealthStatusId { get; set; }
        public string Others { get; set; }

        /// <summary>
        /// نوع المرض أو الإعاقة إن وجد
        /// </summary>
        public string Description { get; set; }
    }

}
