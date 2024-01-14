using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /*
     موظف حكومي
قطاع خاص
طالب / طالبة
متقاعد/ متقاعدة
غير موظف
     */
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
