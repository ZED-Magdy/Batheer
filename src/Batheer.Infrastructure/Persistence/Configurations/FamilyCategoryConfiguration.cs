using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FamilyCategoryConfiguration : IEntityTypeConfiguration<FamilyCategory>
    {
        public void Configure(EntityTypeBuilder<FamilyCategory> builder)
        {

            builder.HasData(
                    new FamilyCategory() { Id = 1, Name = "أرملة" },
                    new FamilyCategory() { Id = 2, Name = "مطلقة" },
                    new FamilyCategory() { Id = 3, Name = "فقيرة" },
                    new FamilyCategory() { Id = 4, Name = "يتيم" }
                    );
        }
    }
}