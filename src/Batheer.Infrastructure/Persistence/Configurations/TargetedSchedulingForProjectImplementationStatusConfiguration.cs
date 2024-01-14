using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class TargetedSchedulingForProjectImplementationStatusConfiguration : IEntityTypeConfiguration<TargetedSchedulingForProjectImplementationStatus>
    {
        public void Configure(EntityTypeBuilder<TargetedSchedulingForProjectImplementationStatus> builder)
        {

            builder.HasData(new TargetedSchedulingForProjectImplementationStatus()
            {
                Id = 1,
                Name = "جديد"
            },
            new TargetedSchedulingForProjectImplementationStatus()
            {
                Id = 2,
                Name = "قائمة العوائل المستهدفة معتمدة"
            },
            new TargetedSchedulingForProjectImplementationStatus()
            {
                Id = 3,
                Name = "تم التنفيذ"
            }
            );

        }
    }
}