using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Lookups
{
    /// <summary>
    /// الهجر والمراكز التابعة للمدينة
    /// </summary>
    public class Town
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Name { get; set; }

        public List<AssociationsAffiliatedWithTheCouncilInfo> AssociationsAffiliatedWithTheCouncilInfos { get; set; }

    }
}
