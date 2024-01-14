using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class TheIntendedBeneficiariesOfTheScheduledAssociationProjectConfiguration : IEntityTypeConfiguration<TheIntendedBeneficiariesOfTheScheduledAssociationProject>
    {
        public void Configure(EntityTypeBuilder<TheIntendedBeneficiariesOfTheScheduledAssociationProject> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne<Family>(a => a.Family)
                .WithMany()
                .HasForeignKey(a => a.FamilyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<TargetedSchedulingForProjectImplementation>(a => a.TargetedSchedulingForProjectImplementation)
               .WithMany(m=> m.TheIntendedBeneficiariesOfTheScheduledAssociationProjects)
               .HasForeignKey(a => a.TargetedSchedulingForProjectImplementationId)
               .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject>(a => a.ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject)
                .WithOne(o => o.TheIntendedBeneficiariesOfTheScheduledAssociationProject)
                .HasForeignKey<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProject>(f=> f.TheIntendedBeneficiariesOfTheScheduledAssociationProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
