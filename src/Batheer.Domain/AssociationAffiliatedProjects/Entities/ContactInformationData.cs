using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class ContactInformationData : AuditableEntity
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Mobile { get; set; }
        public string PhoneNumber { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Others { get; set; }
    }
}
