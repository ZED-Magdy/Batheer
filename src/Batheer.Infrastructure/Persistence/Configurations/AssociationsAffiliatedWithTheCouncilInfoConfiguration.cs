using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class AssociationsAffiliatedWithTheCouncilInfoConfiguration : IEntityTypeConfiguration<AssociationsAffiliatedWithTheCouncilInfo>
    {
        public void Configure(EntityTypeBuilder<AssociationsAffiliatedWithTheCouncilInfo> builder)
        {

            builder.HasMany<AssociationsAffiliatedWithTheCouncilInfoActivityType>(a => a.ActivityTypes)
                .WithOne(m => m.AssociationsAffiliatedWithTheCouncilInfo)
                .HasForeignKey(a => a.AssociationsAffiliatedWithTheCouncilInfoId)
                .OnDelete(DeleteBehavior.Restrict);



        }
    }
}