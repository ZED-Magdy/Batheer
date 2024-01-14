using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class HealthStatusConfiguration : IEntityTypeConfiguration<HealthStatus>
    {
        public void Configure(EntityTypeBuilder<HealthStatus> builder)
        {

            builder.HasData(
                   new HealthStatus() { Id = 1, Name = "سليم" },
                   new HealthStatus() { Id = 2, Name = "مريض" },
                   new HealthStatus() { Id = 3, Name = "من ذوي الاحتياجات الخاصة" },
                   new HealthStatus() { Id = 100, Name = "آخر" }
               );
        }
    }
}