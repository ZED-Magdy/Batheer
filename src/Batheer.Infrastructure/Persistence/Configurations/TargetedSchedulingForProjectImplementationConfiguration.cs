using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class TargetedSchedulingForProjectImplementationConfiguration
        : IEntityTypeConfiguration<TargetedSchedulingForProjectImplementation>
    {
        public void Configure(EntityTypeBuilder<TargetedSchedulingForProjectImplementation> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany<TheIntendedBeneficiariesOfTheScheduledAssociationProject>(a => a.TheIntendedBeneficiariesOfTheScheduledAssociationProjects)
                .WithOne(o => o.TargetedSchedulingForProjectImplementation)
                .HasForeignKey(a => a.TargetedSchedulingForProjectImplementationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
