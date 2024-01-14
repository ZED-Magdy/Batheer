﻿using AutoMapper;
using Batheer.Application.Common.Mappings;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.Lookups.Queries.GetActivityTypes
{
    public class ActivityType :
        IMapFrom<Domain.AssociationAffiliatedProjects.Lookups.ActivityType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
