using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    /*
     
     أعزب / عزباء
متزوج / متزوجة
أرملة
مطلق/ مطلقة
آخر
     
     */
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
