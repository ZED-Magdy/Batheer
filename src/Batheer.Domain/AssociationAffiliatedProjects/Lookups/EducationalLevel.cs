using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    /*
     ابتدائي فما دون
متوسط
ثانوي
جامعي
     */
    public class EducationalLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
