using Batheer.Domain;
using Batheer.Domain.AssociationAffiliatedProjects;
using Batheer.Domain.AssociationAffiliatedProjects.Entities;
using Batheer.Domain.AssociationAffiliatedProjects.Lookups;
using Batheer.Domain.AuthenticationUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.IO;

namespace Batheer.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.UserName);

            builder.Property(p => p.UserName)
                .IsRequired();


            builder.HasOne<UploadedFile>(o => o.Photo)
                .WithMany()
                .HasForeignKey(f => f.PhotoId)
                .OnDelete(DeleteBehavior.NoAction);




            builder.HasData(
                   new Domain.AuthenticationUsers.User()
                   {
                       UserName = "admin",
                       Password = "Aa@123456",
                       FullName = "مدير النظام",
                       UserRole = Domain.AuthenticationUsers.User.UserRoles.AdminRole,
                       Mobile = "",
                       //PhotoUrl = "",
                       PhotoId = 1,
                   },
                   new Domain.AuthenticationUsers.User()
                   {
                       UserName = "User_01",
                       Password = "Aa@123456",
                       FullName = "مستخدم 1 - الجمعية الخيرية للرعاية الصحي",
                       UserRole = Domain.AuthenticationUsers.User.UserRoles.CouncilRole,
                       Mobile = "",
                       //PhotoUrl = "",
                       PhotoId = 2,
                   },
                   new Domain.AuthenticationUsers.User()
                   {
                       UserName = "User_03",
                       Password = "Aa@123456",
                       FullName = "مستخدم 1 - جمعية البدع الخيرية",
                       UserRole = Domain.AuthenticationUsers.User.UserRoles.CouncilRole,
                       Mobile = "",
                       //PhotoUrl = "",
                       PhotoId = 3,
                   }


                   );
        }
    }
}