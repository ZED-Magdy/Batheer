using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetAccommodationTypes
{
    public class AccommodationType :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.AccommodationType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
