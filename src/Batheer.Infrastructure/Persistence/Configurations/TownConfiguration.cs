using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasData(
                     new Town() { Id = 1, Name = "أملج", CityId = 5 },
                     //new Town() { Id = 2, Name = "رأس الشيخ حميد", CityId = 7 },
                     //new Town() { Id = 3, Name = "أبيط", CityId = 4 },
                     //new Town() { Id = 4, Name = "الجبعاوية", CityId = 4 },
                     //new Town() { Id = 5, Name = "الجديد", CityId = 4 },
                     //new Town() { Id = 6, Name = "العسافية", CityId = 4 },
                     //new Town() { Id = 7, Name = "الكتيب", CityId = 4 },
                     new Town() { Id = 8, Name = "تيماء", CityId = 4 },
                     //new Town() { Id = 9, Name = "الحزم", CityId = 4 },
                     //new Town() { Id = 10, Name = "الدرة", CityId = 6 },
                     new Town() { Id = 11, Name = "ضباء", CityId = 3 },
                     new Town() { Id = 12, Name = "الوجه", CityId = 2 },
                     new Town() { Id = 13, Name = "أبو راكة", CityId = 2 },
                     new Town() { Id = 14, Name = "بدا", CityId = 2 },

                     new Town() { Id = 15, Name = "الفارعة", CityId = 2 },
                     new Town() { Id = 16, Name = "الكر", CityId = 2 },
                     new Town() { Id = 17, Name = "نابع", CityId = 2 },
                     new Town() { Id = 18, Name = "السديد", CityId = 2 },
                     new Town() { Id = 19, Name = "الخرباء", CityId = 2 },
                     new Town() { Id = 20, Name = "المنجور", CityId = 2 },
                     new Town() { Id = 21, Name = "وادي الجزل", CityId = 2 },

                     new Town() { Id = 22, Name = "الشبحة", CityId = 5 },
                     new Town() { Id = 23, Name = "شثاث", CityId = 5 },
                     new Town() { Id = 24, Name = "الشبعان", CityId = 5 },
                     new Town() { Id = 25, Name = "عمق", CityId = 5 },
                     new Town() { Id = 26, Name = "الشدخ", CityId = 5 },
                     new Town() { Id = 27, Name = "الرويضات", CityId = 5 },
                     new Town() { Id = 28, Name = "مرخ", CityId = 5 },
                     new Town() { Id = 29, Name = "العنجبة", CityId = 5 },

                     new Town() { Id = 30, Name = "الخربطة", CityId = 3 },
                     new Town() { Id = 31, Name = "نابع دما", CityId = 3 },
                     new Town() { Id = 32, Name = "أشواق", CityId = 3 },


                     new Town() { Id = 33, Name = "تبوك", CityId = 1 },
                     new Town() { Id = 34, Name = "بجدة", CityId = 1 },
                     new Town() { Id = 35, Name = "بئر بن هرماس", CityId = 1 },

                     

                     new Town() { Id = 36, Name = "حقل", CityId = 6 },

                     new Town() { Id = 37, Name = "الظلفة", CityId = 1 },
                     new Town() { Id = 38, Name = "أبو القزاز", CityId = 2 },
                     new Town() { Id = 39, Name = "المويلح", CityId = 3 },
                     new Town() { Id = 40, Name = "الجهراء", CityId = 4 },
                     new Town() { Id = 41, Name = "", CityId = 5 },
                     new Town() { Id = 42, Name = "البدع", CityId = 6 }
                     );

            builder.HasMany(m => m.AssociationsAffiliatedWithTheCouncilInfos)
                .WithOne(m => m.Town)
                .HasForeignKey(m => m.TownId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}