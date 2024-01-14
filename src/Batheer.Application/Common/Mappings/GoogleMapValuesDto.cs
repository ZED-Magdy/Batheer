using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Mappings
{
    public class GoogleMapValuesDto : IMapFrom<GoogleMapValues>
    {
        public LatLngDto LatLng { get; set; } = new();
        public MarkerDto Marker { get; set; } = new();
        public int Zoom { get; set; } = 8;
    }

    public record MarkerDto : IMapFrom<Marker>
    {
        public bool draggable { get; set; } = true;
    }

    public class LatLngDto : IMapFrom<LatLng>
    {
        public double lat { get; set; } = 28.22;
        public double lng { get; set; } = 36.54;
    }
}

