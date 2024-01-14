namespace Batheer.DataMigration.Models
{
    public class LoanDataModel
    {
        public int LoanTypeId { get; set; }
        public string Others { get; set; }



        /// <summary>
        /// هل لديك قروض أو التزامات أخرى؟
        /// </summary>
        public bool DoYouHaveLoansOrOtherObligations { get; set; }

        public string Description { get; set; }
    }
}
