using AutoMapper;
using Batheer.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.CouncilProjects.Queries.GetCouncilProjectById
{
    public class CouncilProject : IMapFrom<Domain.CouncilProject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
