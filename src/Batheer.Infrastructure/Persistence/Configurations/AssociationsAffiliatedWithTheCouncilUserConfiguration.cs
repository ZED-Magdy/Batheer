using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class AssociationsAffiliatedWithTheCouncilUserConfiguration : IEntityTypeConfiguration<AssociationsAffiliatedWithTheCouncilUser>
    {
        public void Configure(EntityTypeBuilder<AssociationsAffiliatedWithTheCouncilUser> builder)
        {

            builder.HasData(
                         new AssociationsAffiliatedWithTheCouncilUser()
                         {
                             AssociationsAffiliatedWithTheCouncilId = 100,
                             FullName = "محمد علي",
                             Id = 1,
                             Mobile = "966500000000",
                             PhotoUrl = "",
                             UserName = "User_01"
                         },
                         new AssociationsAffiliatedWithTheCouncilUser()
                         {
                             AssociationsAffiliatedWithTheCouncilId = 100,
                             FullName = "محمد سعيد",
                             Id = 2,
                             Mobile = "966500000000",
                             PhotoUrl = "",
                             UserName = "User_02"
                         },
                         new AssociationsAffiliatedWithTheCouncilUser()
                         {
                             AssociationsAffiliatedWithTheCouncilId = 102,
                             FullName = "محمد عمر",
                             Id = 3,
                             Mobile = "966500000000",
                             PhotoUrl = "",
                             UserName = "User_03"
                         },
                         new AssociationsAffiliatedWithTheCouncilUser()
                         {
                             AssociationsAffiliatedWithTheCouncilId = 103,
                             FullName = "محمد محمد",
                             Id = 4,
                             Mobile = "966500000000",
                             PhotoUrl = "",
                             UserName = "User_04"
                         }
                         );
        }
    }
}