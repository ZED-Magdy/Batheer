using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain
{
    /// <summary>
    /// حسابات المسؤولين (المتطوعين) لكل جمعية على النظام 
    /// </summary>
    public class AssociationsAffiliatedWithTheCouncilUser
    {
        public int Id { get; set; }
        public int AssociationsAffiliatedWithTheCouncilId { get; set; }
        public virtual AssociationsAffiliatedWithTheCouncil AssociationsAffiliatedWithTheCouncil { get; set; }

        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }

    }
}
