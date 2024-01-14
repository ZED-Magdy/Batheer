using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class SupportingFamilyTypeConfiguration : IEntityTypeConfiguration<SupportingFamilyType>
    {
        public void Configure(EntityTypeBuilder<SupportingFamilyType> builder)
        {

            builder.HasData(
                     new SupportingFamilyType() { Id = 1, Name = "أسرة منتجة" }
                     );
        }
    }
}