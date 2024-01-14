using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class ProducedFamilyProductConfiguration : IEntityTypeConfiguration<ProducedFamilyProduct>
    {
        public void Configure(EntityTypeBuilder<ProducedFamilyProduct> builder)
        {

            builder.HasData(
                    new ProducedFamilyProduct() { Id = 1, Name = "حلويات شعبية" },
                    new ProducedFamilyProduct() { Id = 2, Name = "أكلات شعبية" },
                    new ProducedFamilyProduct() { Id = 3, Name = "تصميم ملابس" },
                    new ProducedFamilyProduct() { Id = 4, Name = "تنسيق حفلات" },
                    new ProducedFamilyProduct() { Id = 5, Name = "صنع عطور" },
                    new ProducedFamilyProduct() { Id = 6, Name = "صنع منسوجات" },
                    new ProducedFamilyProduct() { Id = 7, Name = "صنع قهوة" }
                    );
        }
    }
}