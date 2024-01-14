using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class FamilyNeedConfiguration : IEntityTypeConfiguration<FamilyNeed>
    {
        public void Configure(EntityTypeBuilder<FamilyNeed> builder)
        {

            builder.HasMany(m => m.FamilyNeedDetails)
                .WithOne(m => m.FamilyNeed)
                .HasForeignKey(m => m.FamilyNeedId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                     new FamilyNeed() { Id = 1, Name = "مأكل ومشرب" },
                     new FamilyNeed() { Id = 2, Name = "ملبس" },
                     new FamilyNeed() { Id = 3, Name = "فواتير" },
                     new FamilyNeed() { Id = 4, Name = "مسكن" },
                     new FamilyNeed() { Id = 5, Name = "سيولة نقدية" },
                     new FamilyNeed() { Id = 6, Name = "صحي" },
                     new FamilyNeed() { Id = 7, Name = "نفسي" },
                     new FamilyNeed() { Id = 8, Name = "اجتماعي" },
                     new FamilyNeed() { Id = 9, Name = "تطوعي" },
                     new FamilyNeed() { Id = 10, Name = "تعليمي" }
                     );
        }
    }
}