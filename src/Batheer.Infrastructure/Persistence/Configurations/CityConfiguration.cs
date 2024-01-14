using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(
                     new City() { Id = 1, Name = "مدينة تبوك" },
                     new City() { Id = 2, Name = "محافظة الوجه" },
                     new City() { Id = 3, Name = "محافطة ضباء" },
                     new City() { Id = 4, Name = "محافظة تيماء" },
                     new City() { Id = 5, Name = "محافظة أملج" },
                     new City() { Id = 6, Name = "محافظة حقل" }
                     );

            builder.HasMany(m => m.Towns)
                 .WithOne(m => m.City)
                 .HasForeignKey(m => m.CityId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}