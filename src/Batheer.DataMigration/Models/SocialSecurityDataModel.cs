namespace Batheer.DataMigration.Models
{
    public class SocialSecurityDataModel
    {
        public bool AreYouABeneficiaryOfSocialSecurity { get; set; }

        /// <summary>
        /// اسم الجمعية المسجل فيها إن وجدت
        /// </summary>
        public string Description { get; set; }
    }
}
