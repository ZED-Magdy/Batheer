using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class AccommodationTypeConfiguration : IEntityTypeConfiguration<AccommodationType>
    {
        public void Configure(EntityTypeBuilder<AccommodationType> builder)
        {

            builder.HasData(
                    new AccommodationType() { Id = 1, Name = "ملك" },
                    new AccommodationType() { Id = 2, Name = "إيجار" },
                    new AccommodationType() { Id = 100, Name = "آخر" }
                );
        }
    }
}