using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatusConfiguration : IEntityTypeConfiguration<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus>
    {
        public void Configure(EntityTypeBuilder<ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus> builder)
        {

            builder.HasData(
                    new ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus() { Id = 1, Name = "تم التسليم" },
                    new ResultOfTheIntendedBeneficiariesOfTheScheduledAssociationProjectStatus() { Id = 2, Name = "تعذر التسليم" }
                );
        }
    }
}