using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetEstimatedProjectCosts
{
    public class EstimatedProjectCost :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.EstimatedProjectCost>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
