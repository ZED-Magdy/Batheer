using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;
using System.Text.Json;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ResidencyAddressDataConfiguration : IEntityTypeConfiguration<ResidencyAddressData>
    {
        public void Configure(EntityTypeBuilder<ResidencyAddressData> builder)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.General);

            builder.Property(p=>p.GoogleMapValues)
                .HasMaxLength(500)
                .HasConversion(
                toString => JsonSerializer.Serialize(toString, options),
                fromObject => JsonSerializer.Deserialize<GoogleMapValues>(fromObject, options)!,
                ValueComparer.CreateDefault(typeof(GoogleMapValues), true)
            );
        }
    }
}