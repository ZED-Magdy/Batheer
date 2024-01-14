using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
    {
        public void Configure(EntityTypeBuilder<ActivityType> builder)
        {
            builder.HasData(
                     new ActivityType() { Id = 1, Name = "بر" },
                     new ActivityType() { Id = 2, Name = "متخصصة" },
                     new ActivityType() { Id = 3, Name = "دعوة" },
                     new ActivityType() { Id = 4, Name = "تحفيظ" },
                     new ActivityType() { Id = 5, Name = "أيتام" }
                     );

            builder.HasMany(m => m.AssociationActivityTypes)
                 .WithOne(m => m.ActivityType)
                 .HasForeignKey(m => m.ActivityTypeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}