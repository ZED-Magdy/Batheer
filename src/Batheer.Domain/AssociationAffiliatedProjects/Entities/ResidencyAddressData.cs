using Batheer.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Batheer.Domain.AssociationAffiliatedProjects.Entities
{
    public class ResidencyAddressData : AuditableEntity
    {
        public int Id { get; set; }
        public bool IsOutOfTabuk { get; set; }
        public int? ProvinceId { get; set; }
        public string Province { get; set; }

        public string District { get; set; }
        public string Street { get; set; }
        public string Others { get; set; }
        public string LocationOnTheMap { get; set; }

        public GoogleMapValues GoogleMapValues { get; set; } = new GoogleMapValues();

    }

    public class GoogleMapValues
    {
        public LatLng LatLng { get; set; } = new LatLng();
        public Marker Marker { get; set; }  = new Marker();
        public int Zoom { get; set; } = 8;
    }

    public class Marker
    {
        public bool draggable { get; set; } = true;
    }


    public class LatLng
    {
        public double lat { get; set; } = 28.22;
        public double lng { get; set; } = 36.54;
    }
}
