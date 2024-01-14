using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> builder)
        {

            builder.HasData(
                    new MaritalStatus() { Id = 1, Name = "أعزب / عزباء" },
                    new MaritalStatus() { Id = 2, Name = "متزوج / متزوجة" },
                    new MaritalStatus() { Id = 3, Name = "أرملة" },
                    new MaritalStatus() { Id = 4, Name = "مطلق/ مطلقة" },
                    new MaritalStatus() { Id = 100, Name = "آخر" }
                );
        }
    }
}