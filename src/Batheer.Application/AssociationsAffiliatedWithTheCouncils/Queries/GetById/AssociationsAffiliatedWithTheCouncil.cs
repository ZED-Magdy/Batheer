using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.AssociationsAffiliatedWithTheCouncils.Queries.GetById
{
    public class AssociationsAffiliatedWithTheCouncil : IMapFrom<Domain.AssociationsAffiliatedWithTheCouncil>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AboutIt { get; set; }
        public string AdministrativeRestructuring { get; set; }
        public string ContactInformation { get; set; }
        public string LocationOnTheMap { get; set; }
    }
}
