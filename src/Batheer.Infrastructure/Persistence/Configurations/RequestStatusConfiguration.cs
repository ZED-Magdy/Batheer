using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class RequestStatusConfiguration : IEntityTypeConfiguration<RequestStatus>
    {
        public void Configure(EntityTypeBuilder<RequestStatus> builder)
        {

            builder.HasData(
                     new RequestStatus() { Id = 1, Name = "جديد" },
                     new RequestStatus() { Id = 2, Name = "مقبول" },
                     new RequestStatus() { Id = 3, Name = "مرفوض" }
                     );
        }
    }
}