using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Town> Towns { get; set; }
    }
}
