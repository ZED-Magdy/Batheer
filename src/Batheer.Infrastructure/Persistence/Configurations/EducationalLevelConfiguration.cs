using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class EducationalLevelConfiguration : IEntityTypeConfiguration<EducationalLevel>
    {
        public void Configure(EntityTypeBuilder<EducationalLevel> builder)
        {
            builder.HasData(
                                new EducationalLevel() { Id = 1, Name = "ابتدائي فما دون" },
                                new EducationalLevel() { Id = 2, Name = "متوسط" },
                                new EducationalLevel() { Id = 3, Name = "ثانوي" },
                                new EducationalLevel() { Id = 4, Name = "جامعي" },
                                new EducationalLevel() { Id = 99, Name = "غير محدد" }
                            );
        }
    }
}